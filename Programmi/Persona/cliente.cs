using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persona
{
    internal class cliente
    {
        public string Nome;
        public string Cognome;
        public int Età;
        public string Sesso;
        public Macchina[] numeromacchine;
        public cliente(int num)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("cliente.cliente", this);
            this.num = num;
            numeromacchine = new Macchina[num];
        }
        private int num;
        public void acquistaAuto(Macchina m)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("cliente.acquistaAuto", this);

            int i = 0;
            while (numeromacchine[i] != null && i < 5)
                i++;
            if (numeromacchine[i] == null)
            {
                numeromacchine[i] = m;
            }

        }
    }
}
