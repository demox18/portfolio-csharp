using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace persona
{
    internal class Macchina
    {
        public int Cilindrata;
        public string Modello;
        public string Marca;
        public int Velocità;
        public bool Statofreni;
        public bool Accensione;
        public int Giri;
        public Macchina()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Macchina.Macchina", this);
            Accensione = false;
            Statofreni = false;
            Velocità = 0;
            Giri = 0;
        }
        public void spegnimento()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Macchina.spegnimento", this);
            Accensione = false;
            Giri = 0;
            Velocità = 0;
        }
        public void Accensione1()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Macchina.Accensione1", this);
            Accensione = true;
            Giri = 500;
            Velocità= 20;
            
        }
        public void Accelerazione()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Macchina.Accelerazione", this);
            if (Accensione != false)
            {
                Giri = Giri + 500;
                Velocità = Velocità + 20;
            }
            else
            {
                Console.WriteLine("il motore non è acceso");
            }

        }
        public void deccelerazione()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Macchina.deccelerazione", this);
            if (Accensione != false && Giri >= 500)
            {
                Giri = Giri - 500;
                Velocità = Velocità - 20;
            }
            else if (Accensione == false)
                Console.WriteLine("il motore non è acceso");
            else
                Console.WriteLine("la macchina è ferma");
        }
    }
}
