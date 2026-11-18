using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneSquadraNBA
{
    internal class Commissionario
    {
        private string NOME;
        private string COGNOME;
        public Squadra[] Squad; // Vettore di squadre

        // Costruttore della classe Commissionario
        public Commissionario(string n, string c, int nms)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.Commissionario", this);
            NOME = n;
            COGNOME = c;
            Squadra[] Squad = new Squadra[nms]; // Inizializzazione del vettore di squadre
        }

        // Proprietà di sola lettura per ottenere il nome
        public string Nome
        {
            get { return NOME; }
        }

        // Proprietà di sola lettura per ottenere il cognome
        public string Cognome
        {
            get { return COGNOME; }
        }

        // Metodo per gestire l'assegnazione di un giocatore a una squadra
        public void Gestisce(Squadra solosquadra, Giocatore player, Giocatore[] draft)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.Gestisce", this);
            solosquadra.MettiPlayernellaSquadra(player);
            RimuoviGiocatoreDalDraft(player, draft);
        }

        // Metodo privato per riorganizzare il vettore di giocatori (draft)
        private void RiorganizzaDraft(Giocatore[] draft)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.RiorganizzaDraft", this);
            int indice = 0;
            for (int i = 0; i < draft.Length; i++)
            {
                if (draft[i] != null)
                {
                    draft[indice] = draft[i];
                    indice++;
                }
            }
            for (int i = indice; i < draft.Length; i++)
            {
                draft[i] = null;
            }
        }

        // Metodo privato per rimuovere un giocatore dal vettore di giocatori (draft)
        private void RimuoviGiocatoreDalDraft(Giocatore giocatore, Giocatore[] draft)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.RimuoviGiocatoreDalDraft", this);
            for (int i = 0; i < draft.Length; i++)
            {
                if (draft[i] == giocatore)
                {
                    draft[i] = null;
                    RiorganizzaDraft(draft);
                    return;
                }
            }
            Console.WriteLine("\r\nIl giocatore non è nel draft\r\n");
        }

        // Metodo pubblico per visualizzare tutte le squadre
        public void VisualizzaTutteLeSquadreDecapsulamento(Squadra[] squadre)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.VisualizzaTutteLeSquadreDecapsulamento", this);
            VisualizzaTutteLeSquadre(squadre);
        }

        // Metodo privato per visualizzare tutte le squadre
        private void VisualizzaTutteLeSquadre(Squadra[] squadre)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.VisualizzaTutteLeSquadre", this);
            Console.WriteLine("\r\nTutte le squadre:\r\n");

            for (int i = 0; i < squadre.Length && squadre[i] != null; i++)
            {
                Console.WriteLine($"{i + 1}) {squadre[i].Nome} in {squadre[i].Posizione} - n° campionati vinti: {squadre[i].Campionati}");
            }
        }

        // Metodo pubblico per visualizzare i giocatori di una squadra
        public async Task VisualizzaGiocatoriDiUnaSquadraDecapsulamento(Squadra[] squadre)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.VisualizzaGiocatoriDiUnaSquadraDecapsulamento", this);
            await VisualizzaGiocatoriDiUnaSquadra(squadre);
        }

        // Metodo privato per visualizzare i giocatori di una squadra
        private async Task VisualizzaGiocatoriDiUnaSquadra(Squadra[] squadre)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Commissionario.VisualizzaGiocatoriDiUnaSquadra", this);
            Console.WriteLine("Seleziona una squadra:\r\n");

            for (int i = 0; i < squadre.Length && squadre[i] != null; i++)
            {
                Console.WriteLine($"{i + 1}) {squadre[i].Nome}");
            }
            Console.WriteLine();
            int numeroSquadra = Convert.ToInt32((await Console.ReadLine()));

            if (numeroSquadra < 1 || numeroSquadra > squadre.Length || squadre[numeroSquadra - 1] == null)
            {
                Console.WriteLine("\r\nSelezione non valida\r\n");
                return;
            }

            Console.WriteLine($"\r\nGiocatori della squadra {squadre[numeroSquadra - 1].Nome}:\r\n");

            if (squadre[numeroSquadra - 1].Playersq == null)
            {
                Console.WriteLine("\r\nNessun giocatore nella squadra");
                return;
            }

            for (int i = 0; i < squadre[numeroSquadra - 1].Playersq.Length && squadre[numeroSquadra - 1].Playersq[i] != null; i++)
            {
                Console.WriteLine($"{i + 1}) {squadre[numeroSquadra - 1].Playersq[i].Nome} {squadre[numeroSquadra - 1].Playersq[i].Cognome}");
            }

            Console.WriteLine("\r\nVuoi vedere i dati di un giocatore? (Sì/No)\r\n");
            string risposta = (await Console.ReadLine());

            if (risposta.ToLower() == "sì" || risposta.ToLower() == "si")
            {
                Console.WriteLine("\r\nSeleziona il numero del giocatore:\r\n");
                int numeroGiocatore = Convert.ToInt32((await Console.ReadLine()));
                if (numeroGiocatore < 1 || numeroGiocatore > squadre[numeroSquadra - 1].Playersq.Length || squadre[numeroSquadra - 1].Playersq[numeroGiocatore - 1] == null)
                {
                    Console.WriteLine("\r\nSelezione non valida.");
                    return;
                }
                Giocatore giocatoreSelezionato = squadre[numeroSquadra - 1].Playersq[numeroGiocatore - 1];
                Console.WriteLine($"\r\nDati del giocatore {giocatoreSelezionato.Nome} {giocatoreSelezionato.Cognome}:\r\n");
                Console.WriteLine($"Valutazione tiro: {giocatoreSelezionato.Vtiro}%");
                Console.WriteLine($"Valutazione difesa: {giocatoreSelezionato.Vdifesa}%");
                Console.WriteLine($"Valutazione assist: {giocatoreSelezionato.Vassist}%");
            }
        }
    }

}
