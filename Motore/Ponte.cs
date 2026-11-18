using System.Text.Json;
using Microsoft.JSInterop;

namespace Demox.Motore;

// Collega la pagina web ai programmi C#: avvio, input, clic sui pulsanti delle finestre.
public static class Ponte
{
    public static IJSInProcessRuntime JS = null!;
    static int generazione;

    public static void Evento(object dati) => JS.InvokeVoid("demoxEvento", JsonSerializer.Serialize(dati));

    [JSInvokable]
    public static async Task Avvia(string programma)
    {
        int mia = ++generazione;
        Console.Reset();
        Traccia.Reset();
        Finto.FileSystem.Reset();
        Evento(new { t = "start", p = programma });
        try
        {
            var args = Array.Empty<string>();
            switch (programma)
            {
                case "console-demox": await console_di_demox.Program.Avvio(args); break;
                case "squadra-nba": await GestioneSquadraNBA.Program.Avvio(args); break;
                case "vettore-dinamico": await Vettore_dinamico.Program.Avvio(args); break;
                case "persona": await persona.Program.Avvio(args); break;
                case "pila": Finestre.Apri(new Pila.Form1()); return;
                case "gestione-libri": Finestre.Apri(new GestioneLibri.Form1()); return;
            }
            if (mia == generazione) Evento(new { t = "end" });
        }
        catch (OperationCanceledException) { }
        catch (Exception e)
        {
            // come una console vera: il programma si ferma e si vede l'errore
            if (mia == generazione) Evento(new { t = "crash", tipo = e.GetType().Name, msg = e.Message });
        }
    }

    [JSInvokable]
    public static void Input(string riga) => Console.Invia(riga);

    [JSInvokable]
    public static string Clic(string pulsante, string campiJson)
    {
        var campi = JsonSerializer.Deserialize<Dictionary<string, string>>(campiJson) ?? new();
        try { Finestre.Clic(pulsante, campi); }
        catch (Exception e) { Evento(new { t = "crash", tipo = e.GetType().Name, msg = e.Message, continua = true }); }
        return JsonSerializer.Serialize(Finestre.Stato());
    }
}
