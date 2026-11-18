using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSquadraNBA
{
    internal class Giocatore
    {
        Random random = new Random(); // Oggetto Random per generare valori casuali

        private string NOME; // Nome del giocatore
        private string COGNOME; // Cognome del giocatore
        private int VTIRO; // Valutazione del tiro del giocatore
        private int VDIFESA; // Valutazione della difesa del giocatore
        private int VASSIST; // Valutazione dell'assistenza del giocatore

        // Costruttore della classe Giocatore
        public Giocatore(string n, string c)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Giocatore.Giocatore", this);
            NOME = n;
            COGNOME = c;
        }

        // Proprietà di sola lettura per ottenere il nome del giocatore
        public string Nome
        {
            get { return NOME; }
        }

        // Proprietà di sola lettura per ottenere il cognome del giocatore
        public string Cognome
        {
            get { return COGNOME; }
        }

        // Proprietà di sola lettura per ottenere la valutazione del tiro del giocatore
        public int Vtiro
        {
            get { return VTIRO; }
        }

        // Proprietà di sola lettura per ottenere la valutazione della difesa del giocatore
        public int Vdifesa
        {
            get { return VDIFESA; }
        }

        // Proprietà di sola lettura per ottenere la valutazione dell'assistenza del giocatore
        public int Vassist
        {
            get { return VASSIST; }
        }

        // Metodo per impostare le abilità del giocatore
        public async Task Abilita(bool scelta)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Giocatore.Abilita", this);
            if (scelta == true)
            {
                Console.WriteLine("Inserisci la probabilità di canestro:");
                VTIRO = Convert.ToInt32((await Console.ReadLine()));

                Console.WriteLine("Inserisci la probabilità di difesa:");
                VDIFESA = Convert.ToInt32((await Console.ReadLine()));

                Console.WriteLine("Inserisci la probabilità di assistenza:");
                VASSIST = Convert.ToInt32((await Console.ReadLine()));
            }
            else
            {
                // Se la scelta è falsa, assegna valori casuali alle abilità
                VTIRO = random.Next(1, 100);
                VDIFESA = random.Next(1, 100);
                VASSIST = random.Next(1, 100);
            }
        }
    }

}
