using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace persona
{
    internal class Program
    {
        public static async Task Avvio(string[] args)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Program.Avvio", null);
            Console.WriteLine("Numero di macchine possedute della prima persona: ");
            int numeromacchine = Convert.ToInt32((await Console.ReadLine()));

            cliente P1 = new cliente(numeromacchine);
            //cliente P2 = new cliente();

            Console.WriteLine("Nome della prima persona: ");
            P1.Nome = (await Console.ReadLine());
            Console.WriteLine($"Cognome di {P1.Nome}: ");
            P1.Cognome = (await Console.ReadLine());
            Console.WriteLine($"Età di {P1.Nome}: ");
            P1.Età = Convert.ToInt32((await Console.ReadLine()));
            Console.WriteLine($"Sesso di {P1.Nome}: ");
            P1.Sesso = (await Console.ReadLine());
            //Console.WriteLine("Numero di macchine possedute della prima persona: ");
            //P1.numeromacchine = new int[Convert.ToInt32((await Console.ReadLine()))];

            //Console.WriteLine("Nome della seconda persona: ");
            //P2.Nome = (await Console.ReadLine());
            //Console.WriteLine("Cognome della seconda persona: ");
            //P2.Cognome = (await Console.ReadLine());
            //Console.WriteLine("Età della seconda Persona: ");
            //P2.Età = Convert.ToInt32((await Console.ReadLine()));
            //Console.WriteLine("Sesso della seconda persona: ");
            //P2.Sesso = (await Console.ReadLine());

            Macchina M = new Macchina();
            //Macchina M2 = new Macchina();

            Console.WriteLine("Numero della cilindrata: ");
            M.Cilindrata = Convert.ToInt32((await Console.ReadLine()));
            Console.WriteLine("Il nome della prima macchina: ");
            M.Modello = (await Console.ReadLine());
            Console.WriteLine("Marca prima macchina: ");
            M.Marca = (await Console.ReadLine());
            Console.WriteLine("Velocità della prima macchina: ");
            M.Velocità = Convert.ToInt32((await Console.ReadLine()));
            Console.WriteLine("Stato Inziale della prima macchina: ");

            P1.acquistaAuto(M);
            //Console.WriteLine($"Nome: {P1.Nome} Cognome: {P1.Cognome}");
            //for (int i = 0; i < 5; i++)
            //{
            //    if (P1.numeromacchine[i] != null)
            //        Console.WriteLine($"{P1.numeromacchine[i].Modello} {P1.numeromacchine[i].Marca}");
            //}
            //Console.ReadKey();
            //Console.WriteLine("Numero cilindrata della seconda macchina: ");
            //M2.Cilindrata = Convert.ToInt32((await Console.ReadLine()));
            //Console.WriteLine("Modello della seconda macchina: ");
            //M2.Modello = (await Console.ReadLine());
            //Console.WriteLine("Marca della seconda macchina: ");
            //M2.Marca = (await Console.ReadLine());
            //Console.WriteLine("Velocità della seconda macchina: ");
            //M2.Velocità = Convert.ToInt32((await Console.ReadLine()));
            //Console.WriteLine("Stato Inziale della seconda macchina: ");

            Console.WriteLine($"\r\nMacchina 1: \r\nstato motore: {M.Accensione}\r\nNumero di giri: {M.Giri}\r\nPer accendere la macchina premi enter...");
            await Console.ReadKey();
            M.Accensione1();
            Console.WriteLine($"\r\nMacchina 1: \r\nstato motore: {M.Accensione}\r\nNumero di giri: {M.Giri}\r\nVelocità: {M.Velocità}");
            int azione = 1;
            while (azione >= 1)
            {
                Console.WriteLine("Che vuoi fare? Per accelerare premi 1 per deccelerare premi 2 per spegnere il motore premi 3 per accendere di nuovo la macchina premere 4");
                azione = Convert.ToInt32((await Console.ReadLine()));
                if (azione == 1)
                {
                    M.Accelerazione();
                }
                else if (azione == 2)
                {
                    M.deccelerazione();
                }
                else if (azione == 3)
                {
                    M.spegnimento();
                }
                else if (azione == 4)
                {
                    M.Accensione1();
                }
                Console.WriteLine($"\r\nMacchina 1: \r\nstato motore: {M.Accensione}\r\nNumero di giri: {M.Giri}\r\nVelocità: {M.Velocità}");


            };
            await Console.ReadKey();


        }
    }
}
