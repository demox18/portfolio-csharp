# Adatta i sorgenti C# di demox per girare nel browser:
# 1) input da console asincrono (await), 2) Main rinominato Avvio, 3) traccia dei metodi per la mappa logica.
import re, sys, pathlib
root = pathlib.Path(sys.argv[1])

def sub(path, old, new, count=0):
    p = root / path; s = p.read_text(encoding="utf-8-sig")
    if old not in s: raise SystemExit(f"non trovato in {path}: {old[:60]}")
    s = s.replace(old, new) if count == 0 else s.replace(old, new, count)
    p.write_text(s, encoding="utf-8")

# --- input asincrono ---
for f in root.glob("Programmi/*/*.cs"):
    s = f.read_text(encoding="utf-8-sig")
    s = re.sub(r"(?<!//)Console\.ReadLine\(\)", "(await Console.ReadLine())", s)
    s = re.sub(r"^(\s*)Console\.(Read|ReadKey)\(\);", r"\1await Console.\2();", s, flags=re.M)
    s = re.sub(r"^(\s*)\(await Console\.ReadLine\(\)\);", r"\1await Console.ReadLine();", s, flags=re.M)
    s = s.replace("static void Main(string[] args)", "public static async Task Avvio(string[] args)")
    f.write_text(s, encoding="utf-8")

# Persona: riattivo il ciclo della macchina che era commentato nel Main
p = root / "Programmi/Persona/Program.cs"
lines = p.read_text(encoding="utf-8").split("\n")
for i in range(70, 99):
    lines[i] = re.sub(r"^(\s*)//", r"\1", lines[i])
s = "\n".join(lines)
s = s.replace("Console.ReadKey();\n            M.Accensione1();", "await Console.ReadKey();\n            M.Accensione1();")
s = re.sub(r"(Accensione1\(\);[^\n]*\n[^\n]*\n\s*int azione = 1;)", r"\1", s)
p.write_text(s, encoding="utf-8")

# metodi che leggono l'input diventano async
sub("Programmi/NBA/Giocatore.cs", "public void Abilita(bool scelta)", "public async Task Abilita(bool scelta)")
sub("Programmi/NBA/Squadra.cs", "public void VisualizzaSquadra()", "public async Task VisualizzaSquadra()")
sub("Programmi/NBA/Commissionario.cs", "public void VisualizzaGiocatoriDiUnaSquadraDecapsulamento(Squadra[] squadre)", "public async Task VisualizzaGiocatoriDiUnaSquadraDecapsulamento(Squadra[] squadre)")
sub("Programmi/NBA/Commissionario.cs", "            VisualizzaGiocatoriDiUnaSquadra(squadre);", "            await VisualizzaGiocatoriDiUnaSquadra(squadre);")
sub("Programmi/NBA/Commissionario.cs", "private void VisualizzaGiocatoriDiUnaSquadra(Squadra[] squadre)", "private async Task VisualizzaGiocatoriDiUnaSquadra(Squadra[] squadre)")
sub("Programmi/NBA/Program.cs", ".Abilita(true);", ".Abilita(true).ConfigureAwait(true);")
s = (root/"Programmi/NBA/Program.cs").read_text(encoding="utf-8")
s = s.replace("draft[indicegiocatore].Abilita(true).ConfigureAwait(true);", "await draft[indicegiocatore].Abilita(true);")
s = s.replace("draft[indicegiocatore].Abilita(false);", "await draft[indicegiocatore].Abilita(false);")
s = s.replace("admin.VisualizzaGiocatoriDiUnaSquadraDecapsulamento(admin.Squad);", "await admin.VisualizzaGiocatoriDiUnaSquadraDecapsulamento(admin.Squad);")
(root/"Programmi/NBA/Program.cs").write_text(s, encoding="utf-8")

# --- traccia: all'inizio di ogni metodo/costruttore ---
decl = re.compile(r"^(\s*)((?:public|private|internal|protected|static|async|override|void|string|int|bool|object|Task|\s)+)\s*(?:[\w<>\[\]]+\s+)?(\w+)\s*\(([^;{}]*)\)\s*$")
skip = {"if", "while", "for", "foreach", "switch", "catch", "using", "lock", "return"}
for f in root.glob("Programmi/*/*.cs"):
    out, cls = [], None
    src = f.read_text(encoding="utf-8").split("\n")
    i = 0
    while i < len(src):
        line = src[i]; out.append(line)
        m = re.search(r"\bclass\s+(\w+)", line)
        if m and not line.strip().startswith("//"): cls = m.group(1)
        d = decl.match(line) if not line.strip().startswith("//") else None
        local = re.match(r"^\s*(void|string|int|bool)\s+(\w+)\s*\(([^;{}]*)\)\s*$", line)
        name = None; static = False
        if d and d.group(3) not in skip:
            name = d.group(3); static = "static" in d.group(2)
        elif local and local.group(2) not in skip:
            name = local.group(2); static = True  # funzione locale dentro Main
        if name and i + 1 < len(src) and src[i + 1].strip() == "{":
            i += 1; out.append(src[i])
            ind = re.match(r"^(\s*)", src[i]).group(1) + "    "
            who = "null" if (static or "ConsoleDemox/Program.cs" in str(f)) else "this"
            out.append(f'{ind}using var __traccia = global::Demox.Motore.Traccia.Entra("{cls}.{name}", {who});')
        i += 1
    f.write_text("\n".join(out), encoding="utf-8")
print("ok")
