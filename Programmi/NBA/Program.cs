using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSquadraNBA
{
    internal class Program
    {
        public static async Task Avvio(string[] args)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Program.Avvio", null);
            // Inizializzazione delle variabili
            string temp, temp1;
            int tempnum = 0, tempnum1 = 0;
            int azione = 1;
            int indicesquadra = 0;
            int indicegiocatore = 0;
            Giocatore[] draft = new Giocatore[30];

            // Creazione di un oggetto Commissionario
            Console.WriteLine("Come ti chiami?\r\n");
            temp = (await Console.ReadLine());
            Console.WriteLine($"\r\n{temp} qual è il tuo cognome?\r\n");
            temp1 = (await Console.ReadLine());
            Commissionario admin = new Commissionario(temp, temp1, 30);
            admin.Squad = new Squadra[30];

            // Per provare
            //Commissionario admin = new Commissionario("Mario", "Rossi", 30);
            //admin.Squad = new Squadra[30];
            //admin.Squad[0] = new Squadra("Warriors", "NewYork", 10);
            //admin.Squad[1] = new Squadra("lakers", "NewYork", 10);
            //admin.Squad[2] = new Squadra("Spurs", "NewYork", 10);
            //draft[0] = new Giocatore("Curry", "Stephen");
            //draft[1] = new Giocatore("James", "Lebron");
            //draft[2] = new Giocatore("Leonard", "Kawaii");
            //draft[0].Abilita(false);
            //draft[1].Abilita(false);
            //draft[2].Abilita(false);

            // Il benvenuto sul programma
            Console.WriteLine($"\r\nSalve {admin.Nome}, benvenuto nel nostro programma.");

            //Ciclo per menu
            while (azione >= 1)
            {
                // Menu delle opzioni
                Console.WriteLine("\r\nChe vuoi fare?\r\n\r\n" +
                    "Per creare una squadra premi 1 \r\n" +
                    "Per creare un giocatore premi 2 \r\n" +
                    "Per mettere un giocatore nella squadra premi 3 \r\n" +
                    "Per visualizzare tutte le squadre premi 4 \r\n" +
                    "Per per visualizzare i giocatore di una squadra premi 5 \r\n" +
                    "per uscire premi 0\r\n");
                azione = Convert.ToInt32((await Console.ReadLine()));

                // Azione 1: Creare una nuova squadra
                if (azione == 1)
                {
                    // Chiede all'utente di inserire il nome della squadra
                    Console.WriteLine();
                    Console.WriteLine("Come si chiama la squadra?\r\n");
                    temp = (await Console.ReadLine());

                    // Chiede all'utente di inserire la posizione della squadra
                    Console.WriteLine($"Dove si trova la squadra {temp}?\r\n");
                    temp1 = (await Console.ReadLine());

                    // Chiede all'utente di inserire il numero di campionati vinti dalla squadra
                    Console.WriteLine("Quanti campionati ha vinto?\r\n");
                    tempnum = Convert.ToInt32((await Console.ReadLine()));

                    // Verifica se il vettore di squadre nell'oggetto Commissionario è stato inizializzato
                    // e se c'è spazio per aggiungere un'altra squadra
                    if (admin.Squad != null && indicesquadra < admin.Squad.Length)
                    {
                        // Creazione di una nuova istanza della classe Squadra e assegnazione I di squadre
                        admin.Squad[indicesquadra] = new Squadra(temp, temp1, tempnum);
                        indicesquadra++; // Incrementa l'indice delle squadre per il successivo inserimento
                    }
                    else
                    {
                        // Avvisa l'utente se è stato raggiunto il numero massimo di squadre consentito
                        Console.WriteLine("Hai raggiunto il numero massimo di squadre\r\n");
                    }
                }
                // Azione 2: Creare un nuovo giocatore
                else if (azione == 2)
                {
                    // Chiede all'utente di inserire il nome del giocatore
                    Console.WriteLine();
                    Console.WriteLine("\r\nCome si chiama il giocatore?\r\n");
                    temp = (await Console.ReadLine());

                    // Chiede all'utente di inserire il cognome del giocatore
                    Console.WriteLine($"\r\n{temp} qual è il suo cognome?\r\n");
                    temp1 = (await Console.ReadLine());

                    // Verifica se il vettore di giocatori (draft) è stato inizializzato
                    // e se c'è spazio per aggiungere un nuovo giocatore
                    if (draft != null && indicegiocatore < draft.Length)
                    {
                        // Creazione di un nuovo giocatore nel vettore di giocatori (draft)
                        draft[indicegiocatore] = new Giocatore(temp, temp1);

                        // Chiede all'utente se vuole specificare manualmente le abilità del giocatore
                        Console.WriteLine("\r\nVuoi scrivere tu le abilità? (Sì/No)\r\n");
                        temp = (await Console.ReadLine());

                        if (temp.ToLower() == "sì" || temp.ToLower() == "si")
                        {
                            await draft[indicegiocatore].Abilita(true); // Imposta manualmente le abilità del giocatore
                        }
                        else
                        {
                            await draft[indicegiocatore].Abilita(false); // Utilizza abilità predefinite
                        }

                        indicegiocatore++; // Incrementa l'indice dei giocatori per il successivo inserimento
                    }
                    else
                    {
                        // Avvisa l'utente se è stato raggiunto il numero massimo di giocatori consentito
                        Console.WriteLine("Hai raggiunto il numero massimo di giocatori\r\n");
                    }
                }
                // Azione 3: Mettere un giocatore nella squadra
                else if (azione == 3)
                {
                    Console.WriteLine();
                    tempnum1 = 0;

                    // Conta il numero di giocatori nel vettore di giocatori (draft)
                    while (tempnum1 < draft.Length && draft[tempnum1] != null)
                    {
                        tempnum1++;
                    }

                    // Visualizza l'elenco dei giocatori disponibili
                    for (int i = 0; i < tempnum1; i++)
                    {
                        Console.WriteLine($"{i + 1}) {draft[i].Nome} {draft[i].Cognome}");
                    }

                    // Chiede all'utente di selezionare un giocatore
                    Console.WriteLine("\r\nSeleziona un giocatore (inserisci il numero):\r\n");
                    tempnum = Convert.ToInt32((await Console.ReadLine()));

                    // Verifica la validità della selezione del giocatore
                    if (tempnum < 1 || tempnum > tempnum1)
                    {
                        Console.WriteLine("\r\nSelezione non valida.\r\n");
                    }
                    else
                    {
                        tempnum1 = 0;

                        // Conta il numero di squadre nel vettore di squadre (admin.Squad)
                        while (tempnum1 < admin.Squad.Length && admin.Squad[tempnum1] != null)
                        {
                            tempnum1++;
                        }

                        // Visualizza l'elenco delle squadre disponibili
                        Console.WriteLine("\r\nSeleziona una squadra (inserisci il numero):\r\n");
                        for (int i = 0; i < tempnum1; i++)
                        {
                            Console.WriteLine($"{i + 1}) {admin.Squad[i].Nome}");
                        }

                        Console.WriteLine();

                        // Chiede all'utente di selezionare una squadra
                        tempnum1 = Convert.ToInt32((await Console.ReadLine()));

                        // Verifica la validità della selezione della squadra
                        if (tempnum1 < 1 || tempnum1 > admin.Squad.Length)
                        {
                            Console.WriteLine("\r\nSelezione non valida.\r\n");
                        }
                        else
                        {
                            Console.WriteLine($"\r\nHai messo {draft[tempnum - 1].Nome} {draft[tempnum - 1].Cognome} ai {admin.Squad[tempnum1 - 1].Nome}");

                            // Chiamata al metodo Gestisce dell'oggetto Commissionario per gestire l'assegnazione del giocatore alla squadra
                            admin.Gestisce(admin.Squad[tempnum1 - 1], draft[tempnum - 1], draft);

                            // Decremento dell'indice dei giocatori per gestire il successivo inserimento
                            indicegiocatore--;
                        }
                    }
                }
                // Azione 4: Visualizzare tutte le squadre
                else if (azione == 4)
                {
                    admin.VisualizzaTutteLeSquadreDecapsulamento(admin.Squad);
                }
                // Azione 5: Visualizzare i giocatori di una squadra
                else if (azione == 5)
                {
                    Console.WriteLine();
                    await admin.VisualizzaGiocatoriDiUnaSquadraDecapsulamento(admin.Squad);
                }
            }
        }
    }
}
