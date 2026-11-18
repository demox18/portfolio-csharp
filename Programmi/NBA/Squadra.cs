using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSquadraNBA
{
    internal class Squadra
    {
        private string NOME; // Nome della squadra
        private string POSIZIONE; // Posizione della squadra
        private int CAMPIONATI; // Numero di campionati vinti
        public Giocatore[] Playersq; // Vettore di giocatori della squadra

        // Costruttore della classe Squadra
        public Squadra(string n, string p, int c)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Squadra.Squadra", this);
            NOME = n;
            POSIZIONE = p;
            CAMPIONATI = c;
        }

        // Proprietà di sola lettura per ottenere il nome della squadra
        public string Nome
        {
            get { return NOME; }
        }

        // Proprietà di sola lettura per ottenere la posizione della squadra
        public string Posizione
        {
            get { return POSIZIONE; }
        }

        // Proprietà di sola lettura per ottenere il numero di campionati vinti
        public int Campionati
        {
            get { return CAMPIONATI; }
        }

        // Metodo per aggiungere un giocatore alla squadra
        public void MettiPlayernellaSquadra(Giocatore player)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Squadra.MettiPlayernellaSquadra", this);
            // Se il vettore di giocatori è null, lo inizializza
            if (Playersq == null)
            {
                Playersq = new Giocatore[15];
            }

            // Trova la prima posizione disponibile nel vettore di giocatori
            int i = 0;
            while (i < Playersq.Length && Playersq[i] != null)
                i++;

            // Se è presente una posizione disponibile, aggiunge il giocatore alla squadra
            if (Playersq[i] == null)
            {
                Playersq[i] = player;
            }
        }

        // Metodo per visualizzare le informazioni sulla squadra
        public async Task VisualizzaSquadra()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Squadra.VisualizzaSquadra", this);
            Console.WriteLine("Nome Squadra: " + Nome);
            Console.WriteLine("Posizione della Squadra: " + Posizione);
            Console.WriteLine("Campionati vinti: " + Campionati);
            await Console.ReadLine();
        }
    }

}
