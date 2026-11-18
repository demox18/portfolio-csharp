// Un Windows Forms "finto", quanto basta per far girare Form1.cs di Pila e GestioneLibri così come sono:
// i controlli tengono solo il testo/la lista, e la pagina web li disegna.
namespace System.Windows.Forms
{
    public class Control { public string Text { get; set; } = ""; public string Name { get; set; } = ""; }
    public class Form : Control { }
    public class Button : Control { public event EventHandler? Click; public void PerformClick() => Click?.Invoke(this, EventArgs.Empty); }
    public class TextBox : Control { }
    public class Label : Control { }
    public class ListBox : Control
    {
        public ObjectCollection Items { get; } = new();
        public class ObjectCollection : List<object?> { public new void Add(object? o) => base.Add(o); }
        public event EventHandler? SelectedIndexChanged;
    }
}

namespace Demox.Motore
{
    using System.Reflection;
    using System.Windows.Forms;

    public static class Finestre
    {
        static Form? aperta;

        public static void Apri(Form f)
        {
            aperta = f;
            Ponte.Evento(new { t = "form", stato = Stato() });
        }

        static IEnumerable<(string nome, Control c)> Controlli()
        {
            if (aperta == null) yield break;
            foreach (var f in aperta.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public))
                if (f.GetValue(aperta) is Control c) yield return (f.Name, c);
        }

        public static void Clic(string pulsante, Dictionary<string, string> campi)
        {
            foreach (var (nome, c) in Controlli())
                if (c is TextBox && campi.TryGetValue(nome, out var v)) c.Text = v;
            foreach (var (nome, c) in Controlli())
                if (nome == pulsante && c is Button b) b.PerformClick();
        }

        public static object Stato() => Controlli().Select(x => new
        {
            nome = x.nome,
            tipo = x.c.GetType().Name,
            testo = x.c.Text,
            lista = (x.c as ListBox)?.Items.Select(i => i?.ToString()).ToArray()
        }).ToArray();
    }
}
