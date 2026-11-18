namespace Demox.Motore.Finto;

// Un piccolo disco finto in stile Windows (con le barre \) per i comandi cd, cd.., dir della Console di demox.
public static class FileSystem
{
    public static string Corrente = @"C:\Users\demox";
    static readonly Dictionary<string, string[]> cartelle = new(StringComparer.OrdinalIgnoreCase);
    static readonly Dictionary<string, string[]> files = new(StringComparer.OrdinalIgnoreCase);

    public static void Reset()
    {
        Corrente = @"C:\Users\demox";
        cartelle.Clear(); files.Clear();
        cartelle[@"C:"] = ["Users", "Windows", "Programmi"];
        cartelle[@"C:\Users"] = ["demox"];
        cartelle[@"C:\Users\demox"] = ["Desktop", "Documenti", "Musica", "Progetti"];
        cartelle[@"C:\Users\demox\Progetti"] = ["Console di demox", "GestioneSquadraNBA", "Pila", "Vettore_dinamico", "sitoprogetto"];
        cartelle[@"C:\Users\demox\Progetti\sitoprogetto"] = ["Iphone16", "Sistema solare", "discord by demox"];
        cartelle[@"C:\Users\demox\Musica"] = ["Tyler, The Creator"];
        files[@"C:\Users\demox"] = ["note.txt"];
        files[@"C:\Users\demox\Desktop"] = ["gioco.exe", "foto.png"];
        files[@"C:\Users\demox\Documenti"] = ["compiti.docx", "orario.pdf"];
        files[@"C:\Users\demox\Musica\Tyler, The Creator"] = ["SHE.mp3", "See You Again.mp3"];
        files[@"C:\Users\demox\Progetti\Console di demox"] = ["Program.cs", "AppConfig.cs"];
    }

    public static string Pulisci(string p)
    {
        p = p.Trim().TrimEnd('\\');
        if (!p.Contains(':')) p = Corrente + "\\" + p;
        var parti = new List<string>();
        foreach (var x in p.Split('\\')) { if (x == "..") { if (parti.Count > 1) parti.RemoveAt(parti.Count - 1); } else if (x != "" && x != ".") parti.Add(x); }
        return string.Join("\\", parti);
    }
    public static bool Esiste(string p) => cartelle.ContainsKey(Pulisci(p)) || Pulisci(p).Equals("C:", StringComparison.OrdinalIgnoreCase);
    public static string[] Cartelle(string p) => cartelle.TryGetValue(Pulisci(p), out var c) ? c.Select(x => Pulisci(p) + "\\" + x).ToArray() : [];
    public static string[] Files(string p) => files.TryGetValue(Pulisci(p), out var f) ? f.Select(x => Pulisci(p) + "\\" + x).ToArray() : [];
    public static bool FileEsiste(string f)
    {
        var pieno = Pulisci(f); var cart = pieno.Contains('\\') ? pieno[..pieno.LastIndexOf('\\')] : "";
        return files.TryGetValue(cart, out var l) && l.Any(x => (cart + "\\" + x).Equals(pieno, StringComparison.OrdinalIgnoreCase));
    }
}

public static class Directory
{
    public static string GetCurrentDirectory() => FileSystem.Corrente;
    public static void SetCurrentDirectory(string p)
    {
        if (!FileSystem.Esiste(p)) throw new System.IO.DirectoryNotFoundException($"Could not find a part of the path '{p}'.");
        FileSystem.Corrente = FileSystem.Pulisci(p);
    }
    public static bool Exists(string? p) => p != null && FileSystem.Esiste(p);
    public static string[] GetDirectories(string p) => FileSystem.Cartelle(p);
    public static string[] GetFiles(string p) => FileSystem.Files(p);
}

public static class File
{
    public static bool Exists(string? f) => f != null && FileSystem.FileEsiste(f);
}

public class ProcessStartInfo { public string FileName { get; set; } = ""; }
public class Process
{
    public ProcessStartInfo StartInfo { get; } = new();
    public bool Start() { Console.WriteLine($"[avvio {StartInfo.FileName}... nel browser non si possono aprire programmi]"); return true; }
}
