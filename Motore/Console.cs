namespace Demox.Motore;

// Prende il posto di System.Console: scrive nella pagina e aspetta l'input dalla pagina.
public static class Console
{
    static TaskCompletionSource<string>? attesa;
    static ConsoleColor fg = ConsoleColor.Gray, bg = ConsoleColor.Black;

    public static void Reset()
    {
        attesa?.TrySetCanceled();
        attesa = null;
        fg = ConsoleColor.Gray; bg = ConsoleColor.Black;
    }

    public static void Invia(string riga)
    {
        Ponte.Evento(new { t = "echo", s = riga });
        attesa?.TrySetResult(riga);
    }

    public static Task<string> ReadLine()
    {
        attesa = new TaskCompletionSource<string>(TaskCreationOptions.RunContinuationsAsynchronously);
        Ponte.Evento(new { t = "input" });
        return attesa.Task;
    }
    public static async Task<int> Read() { var s = await ReadLine(); return s.Length > 0 ? s[0] : 13; }
    public static async Task<string> ReadKey() => await ReadLine();

    public static void Write(object? o) => Ponte.Evento(new { t = "out", s = Convert.ToString(o) ?? "" });
    public static void WriteLine() => Write("\n");
    public static void WriteLine(object? o) => Write((Convert.ToString(o) ?? "") + "\n");
    public static void Clear() => Ponte.Evento(new { t = "clear" });

    public static ConsoleColor ForegroundColor
    {
        get => fg;
        set { fg = value; Ponte.Evento(new { t = "color", fg = (int)fg, bg = (int)bg }); }
    }
    public static ConsoleColor BackgroundColor
    {
        get => bg;
        set { bg = value; Ponte.Evento(new { t = "color", fg = (int)fg, bg = (int)bg }); }
    }
}
