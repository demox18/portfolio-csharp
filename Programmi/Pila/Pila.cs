using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pila
{
    class Pila
    {
        private Vector vett;
        public Pila()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Pila", this);
            vett = new Vector();
        }
        public void Push(string oggetto)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Push", this);
            vett.add(oggetto);
        }
        public void Pop()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Pop", this);
            
            vett.removeAt(vett.count()-1, true); // prendo la posizione dell'elemento con count ma meno 1 perchè count mi da ci sono.
        }
        public void Clear()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Clear", this);
            vett.clear();
        }
        public string Peek(int indice)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Peek", this);
            return vett.elementAt(indice);
        }
        public int Count()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Pila.Count", this);
            return vett.count();
        }
    }
}
