using System.Collections;
using System.Reflection;

namespace Demox.Motore;

// Registra ogni metodo che parte e finisce, con lo stato dell'oggetto: serve alla mappa logica.
public static class Traccia
{
    static int profondita;
    public static void Reset() => profondita = 0;

    public static IDisposable Entra(string nome, object? chi)
    {
        Ponte.Evento(new { t = "in", n = nome, d = profondita });
        profondita++;
        return new Uscita(nome, chi);
    }

    sealed class Uscita(string nome, object? chi) : IDisposable
    {
        public void Dispose()
        {
            profondita = Math.Max(0, profondita - 1);
            Ponte.Evento(new { t = "outm", n = nome, d = profondita, s = chi == null ? null : Fotografa(chi, 0) });
        }
    }

    // Legge i campi (anche privati) di un oggetto, per mostrare cosa c'è dentro
    static object? Fotografa(object? o, int livello)
    {
        if (o == null) return null;
        var tipo = o.GetType();
        if (o is string || tipo.IsPrimitive || o is decimal || o is Enum) return o.ToString();
        if (o is Random) return "Random";
        if (o is IEnumerable lista && o is not string)
        {
            var celle = new List<object?>();
            foreach (var x in lista) { celle.Add(livello < 2 ? Fotografa(x, livello + 1) : x?.ToString()); if (celle.Count > 40) break; }
            return celle;
        }
        // un oggetto "piccolo" (es. Giocatore) dentro un vettore: basta il nome
        var nomeProp = tipo.GetProperty("Nome");
        if (livello > 0 && nomeProp != null) return nomeProp.GetValue(o)?.ToString();
        if (livello > 2) return tipo.Name;
        var campi = new Dictionary<string, object?>();
        foreach (var f in tipo.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic))
        {
            if (f.Name.Contains('<') || typeof(Delegate).IsAssignableFrom(f.FieldType)) continue;
            if (f.FieldType.Namespace == "System.Windows.Forms") continue;
            campi[f.Name] = Fotografa(f.GetValue(o), livello + 1);
        }
        return campi;
    }
}
