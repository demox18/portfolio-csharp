using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.Design;
using System.Xml.Serialization;
using System.Diagnostics;

namespace console_di_demox
{
    internal class Program
    {
        public static async Task Avvio(string[] args)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Program.Avvio", null);
            char eheh = '>';
            bool vita = true;
            string banner = @"
 ♥ created in 01/06/2023 ♥

       ██ 
       ██ 
       ██ 
       ██  ▄██▄  ▄               ▄     ▄▌     ▄ 
    █████ ██  █  ███▄██▄  ▄███▄  █    ██    █▀ █▄▀▀█
  ██  ███ ████▀  █ ▀█ ▀█ ▐█   █▌ ██  █      ▌    ▄█
  ██  ██  ██  ▄█ █  █  █ ▐█   █▌   ██      ▐   █▀
  ████▀   ▀████▀ █▄ █▄ █▄ ▀███▀   ██ ██▄   ▐▄█
                                █▀         ██
   ▀█▄▄▄▄▄▄            ▄▄▄▄▄▄█▀▀ 
           ▀▀▀▀▀▀▀▀▀▀▀▀

demox18 <3:
";
            Console.Write(banner);
            while (vita)
            {
                Random random = new Random();
                string pathapp = Directory.GetCurrentDirectory();
                Console.Write(pathapp + eheh);
                string input = (await Console.ReadLine());
                string[] v = input.Split(' ');
                string uni = "";
                string command = v[0];
                string[] percorsoaffett = pathapp.Split('\\');
                command = command.ToLower();
                if (command == "help")
                {

                    Console.WriteLine("\r\nCommandi sono:\r\n" +
                        "cd <path>: cambia directory\r\n" +
                        "cls: pulisce la console\r\n" +
                        "color <help>: cambia lo sfondo e la scritta\r\n" +
                        "dir <attributo>: fa vedere le cartelle e con /a fa vedere anche i file\r\n" +
                        "exit: ti fa uscire dalla console\r\n" +
                        "help: display dei comandi\r\n");

                }
                if (command == "cd")
                {

                    cd(v, uni);

                }
                if (command == "cd..")
                {

                    backcd(percorsoaffett, uni);

                }
                if (command == "color")
                {
                    color(v);
                }
                if (command == "cls")
                {

                    Console.Clear();//cancella la console
                    Console.Write(banner);

                }
                if (command == "exit")
                {

                    vita = false;

                }
                if (command == "dir")
                {

                    dir(v, pathapp, percorsoaffett);
                    
                }
                if (command == "prova")
                {

                    string file = v[1];

                    if (File.Exists(file))
                    {
                        Process process = new Process();
                        process.StartInfo.FileName = file;
                        process.Start();
                    }
                    else
                    {
                        Console.WriteLine("Si è verificato un errore durante l'avvio dell'applicazione.");
                    }


                }
                if (command == "gioco")
                {
                    int hotdog = 0;
                    string scritta = "";
                    int risposta = 0;
                    int tentativi = 0;
                    Console.WriteLine("scegli un numero se indovini vinci (1 a 9 il numero cambia ogni volta che sbagli):");
                    while (hotdog == 0)
                    {
                        int randomnumber = random.Next(1, 10);
                        scritta = (await Console.ReadLine());
                        if (scritta == "exit")
                        {
                            hotdog = 1;
                        }
                        else
                        {

                            risposta = Convert.ToInt32(scritta);
                            if (risposta == randomnumber)
                            {
                                Console.WriteLine($"hai vinto con {tentativi + 1} tentativi");
                                hotdog = 1;
                            }
                            else
                            {
                                Console.WriteLine("riprova.");
                                tentativi++;
                            }

                        }

                    }

                }
                if (command == "morse")
                {
                    string frase = "";
                    string morsefrase = "";
                    Console.WriteLine("scrivi la frase che vuoi tradurre in morse:");
                    frase = (await Console.ReadLine());
                    frase = frase.ToUpper();
                    for (int i = 0; i < frase.Length; i++)
                    {
                        morsefrase += ConvertToMorse(frase[i]);
                    }
                    Console.WriteLine(morsefrase);
                    await Console.Read();
                }
                if (command == "salva")
                {

                }

            }
            void cd(string[]v, string uni)
            {
                using var __traccia = global::Demox.Motore.Traccia.Entra("Program.cd", null);
                if (v.Length > 2)
                {
                    for (int i = 1; i < v.Length; i++)
                    {
                        uni = uni + v[i] + ' ';
                    }
                    Directory.SetCurrentDirectory(uni);
                }
                else if (v.Length < 3)
                {
                    if (Directory.Exists(v[1]))
                    {
                        Directory.SetCurrentDirectory(v[1]);
                    }
                }
                else
                {
                    Console.WriteLine("la cartella non esiste");
                }
            }
            void backcd(string[] percorsoaffett, string uni)
            {
                using var __traccia = global::Demox.Motore.Traccia.Entra("Program.backcd", null);
                for (int i = 0; i < percorsoaffett.Length - 1; i++)
                {
                    uni = uni + percorsoaffett[i] + '\\';
                }
                Directory.SetCurrentDirectory(uni);
            }
            void color(string[] v)
            {
                using var __traccia = global::Demox.Motore.Traccia.Entra("Program.color", null);
                if (v.Length > 1)
                {
                    if (v[1] == "help")
                        Console.WriteLine("\r\ncolor <numerocolorescritta> <numerocolorebackground>\r\n" +
                            "\r\nI colori sono:\r\n" +
                            "0: Nero\r\n" +
                            "1: Blu scuro\r\n" +
                            "2: Verde scuro\r\n" +
                            "3: Ciano scuro\r\n" +
                            "4: Rosso scuro\r\n" +
                            "5: Magenta scuro\r\n" +
                            "6: Giallo scuro\r\n" +
                            "7: Grigio\r\n" +
                            "8: Grigio scuro\r\n" +
                            "9: Blu\r\n" +
                            "10: Verde\r\n" +
                            "11: Ciano\r\n" +
                            "12: Rosso\r\n" +
                            "13: Magenta\r\n" +
                            "14: Giallo\r\n" +
                            "15: Bianco\r\n" +
                            "\r\nesempio: color 5 9\r\n");
                    else if (v.Length == 2)
                    {
                        int color = Convert.ToInt32(v[1]);
                        switch (color)
                        {

                            case 0:
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case 8:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                            case 9:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 10:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 11:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 12:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 13:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 14:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 15:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;


                        }
                    }
                    else if (v.Length == 3)
                    {
                        int color = Convert.ToInt32(v[1]);
                        switch (color)
                        {

                            case 0:
                                Console.ForegroundColor = ConsoleColor.Black;
                                break;
                            case 1:
                                Console.ForegroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 2:
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.ForegroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 4:
                                Console.ForegroundColor = ConsoleColor.DarkRed;
                                break;
                            case 5:
                                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 6:
                                Console.ForegroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 7:
                                Console.ForegroundColor = ConsoleColor.Gray;
                                break;
                            case 8:
                                Console.ForegroundColor = ConsoleColor.DarkGray;
                                break;
                            case 9:
                                Console.ForegroundColor = ConsoleColor.Blue;
                                break;
                            case 10:
                                Console.ForegroundColor = ConsoleColor.Green;
                                break;
                            case 11:
                                Console.ForegroundColor = ConsoleColor.Cyan;
                                break;
                            case 12:
                                Console.ForegroundColor = ConsoleColor.Red;
                                break;
                            case 13:
                                Console.ForegroundColor = ConsoleColor.Magenta;
                                break;
                            case 14:
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                break;
                            case 15:
                                Console.ForegroundColor = ConsoleColor.White;
                                break;


                        }
                        int bgcolor = Convert.ToInt32(v[2]);
                        switch (bgcolor)
                        {
                            case 0:
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                            case 1:
                                Console.BackgroundColor = ConsoleColor.DarkBlue;
                                break;
                            case 2:
                                Console.BackgroundColor = ConsoleColor.DarkGreen;
                                break;
                            case 3:
                                Console.BackgroundColor = ConsoleColor.DarkCyan;
                                break;
                            case 4:
                                Console.BackgroundColor = ConsoleColor.DarkRed;
                                break;
                            case 5:
                                Console.BackgroundColor = ConsoleColor.DarkMagenta;
                                break;
                            case 6:
                                Console.BackgroundColor = ConsoleColor.DarkYellow;
                                break;
                            case 7:
                                Console.BackgroundColor = ConsoleColor.Gray;
                                break;
                            case 8:
                                Console.BackgroundColor = ConsoleColor.DarkGray;
                                break;
                            case 9:
                                Console.BackgroundColor = ConsoleColor.Blue;
                                break;
                            case 10:
                                Console.BackgroundColor = ConsoleColor.Green;
                                break;
                            case 11:
                                Console.BackgroundColor = ConsoleColor.Cyan;
                                break;
                            case 12:
                                Console.BackgroundColor = ConsoleColor.Red;
                                break;
                            case 13:
                                Console.BackgroundColor = ConsoleColor.Magenta;
                                break;
                            case 14:
                                Console.BackgroundColor = ConsoleColor.Yellow;
                                break;
                            case 15:
                                Console.BackgroundColor = ConsoleColor.White;
                                break;
                            default:
                                Console.BackgroundColor = ConsoleColor.Black;
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Attributo non corretto");
                    }
                }
                else
                {
                    Console.WriteLine("specificare il colore");
                }
            }
            void dir(string[] v, string pathapp, string[] percorsoaffett)
            {
                using var __traccia = global::Demox.Motore.Traccia.Entra("Program.dir", null);
                string[] pathcartelle = Directory.GetDirectories(pathapp);
                string[,] cartelle = new string[pathcartelle.Length, percorsoaffett.Length + 1];
                string[] pathfiles = Directory.GetFiles(pathapp);
                string[,] files = new string[pathfiles.Length, percorsoaffett.Length + 1];
                if (v.Length > 1)
                {
                    if (v[1] == "/a")
                    {
                        for (int i = 0; i < pathcartelle.Length; i++)
                        {
                            string[] percorsi = pathcartelle[i].Split('\\');
                            for (int j = 0; j < percorsi.Length; j++)
                            {
                                cartelle[i, j] = percorsi[j];
                            }
                        }
                        for (int i = 0; i < pathfiles.Length; i++)
                        {
                            string[] percorsi1 = pathfiles[i].Split('\\');
                            for (int j = 0; j < percorsi1.Length; j++)
                            {
                                files[i, j] = percorsi1[j];
                            }
                        }
                        Console.WriteLine("\r\nPercorso attuale " + pathapp + "\r\n");
                        Console.WriteLine("Cartelle:\r\n");
                        for (int i = 0; i < cartelle.GetLength(0); i++)
                        {
                            Console.WriteLine(cartelle[i, cartelle.GetLength(1) - 1]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("\r\nfiles:\r\n");
                        for (int i = 0; i < files.GetLength(0); i++)
                        {
                            Console.WriteLine(files[i, files.GetLength(1) - 1]);
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("Attributo sbagliato");
                    }

                }
                else
                {
                    for (int i = 0; i < pathcartelle.Length; i++)
                    {
                        string[] percorsi = pathcartelle[i].Split('\\');
                        for (int j = 0; j < percorsi.Length; j++)
                        {
                            cartelle[i, j] = percorsi[j];
                        }
                    }
                    Console.WriteLine("\r\nPercorso attuale " + pathapp + "\r\n");
                    for (int i = 0; i < cartelle.GetLength(0); i++)
                    {
                        Console.WriteLine(cartelle[i, cartelle.GetLength(1) - 1]);
                    }
                    Console.WriteLine();
                }
            }
            string ConvertToMorse(char lettera)
            {
                using var __traccia = global::Demox.Motore.Traccia.Entra("Program.ConvertToMorse", null);
                switch (lettera)
                {
                    case 'A':
                        return ".- ";
                    case 'B':
                        return "-... ";
                    case 'C':
                        return "-.-. ";
                    case 'D':
                        return "-.. ";
                    case 'E':
                        return ". ";
                    case 'F':
                        return "..-. ";
                    case 'G':
                        return "--. ";
                    case 'H':
                        return ".... ";
                    case 'I':
                        return ".. ";
                    case 'J':
                        return ".--- ";
                    case 'K':
                        return "-.- ";
                    case 'L':
                        return ".-.. ";
                    case 'M':
                        return "-- ";

                    case 'N':
                        return "-. ";

                    case 'O':
                        return "--- ";

                    case 'P':
                        return ".--. ";

                    case 'Q':
                        return "--.- ";

                    case 'R':
                        return ".-. ";

                    case 'S':
                        return "... ";

                    case 'T':
                        return "- ";

                    case 'U':
                        return "..- ";

                    case 'V':
                        return "...- ";

                    case 'W':
                        return ".-- ";

                    case 'X':
                        return "-..- ";

                    case 'Y':
                        return "-.-- ";

                    case 'Z':
                        return "--.. ";

                    case '0':
                        return "----- ";

                    case '1':
                        return ".---- ";

                    case '2':
                        return "..--- ";

                    case '3':
                        return "...-- ";

                    case '4':
                        return "....- ";

                    case '5':
                        return "..... ";

                    case '6':
                        return "-.... ";

                    case '7':
                        return "--... ";

                    case '8':
                        return "---.. ";

                    case '9':
                        return "----. ";

                    case ' ':
                        return "/ ";

                    default:
                        return " "; // Carattere sconosciuto, lo lascio invariato
                }
            }
        }
    }
}