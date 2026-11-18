using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibri
{
    internal class Biblioteca
    {
        private Vector VD;
        public Biblioteca()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.Biblioteca", this);
            VD = new Vector(1);
        }
        public void AggiungiLibro(object libro)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.AggiungiLibro", this);
            VD.add(libro);
        }

        public void RimuoviLibro()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.RimuoviLibro", this);
            VD.remove();
        }

        public void RimuoviLibroAt(int posizione)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.RimuoviLibroAt", this);
            VD.removeAt(posizione, true);
        }

        public void OrdinaLibri()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.OrdinaLibri", this);
            VD.ordine();
        }

        public void CancellaBiblioteca()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.CancellaBiblioteca", this);
            VD.clear();
        }

        public object VisualizzaLibroIn(int posizione)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.VisualizzaLibroIn", this);
            return VD.elementAt(posizione);
        }

        public int ContaLibri()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Biblioteca.ContaLibri", this);
            return VD.count();
        }

    }
}

