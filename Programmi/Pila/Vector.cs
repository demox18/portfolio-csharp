using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pila
{
    internal class Vector
    {
        private string[] REP;
        private int INDEX;
        private int LUNG;
        public Vector()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.Vector", this);

            clear();

        }
        private void raddoppiaVettore()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.raddoppiaVettore", this);
            LUNG = LUNG * 2;
            string[] tempREP = new string[LUNG];
            for (int i = 0; i < INDEX; i++)
            {
                tempREP[i] = REP[i];
            }
            REP = null;
            REP = tempREP;
        }
        private void dimezzaVettore()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.dimezzaVettore", this);
            LUNG = LUNG / 2;
            string[] tempREP = new string[LUNG];
            for (int i = 0; i < INDEX; i++)
            {
                tempREP[i] = REP[i];
            }
            REP = tempREP;
        }
        public void add(string element)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.add", this);

            if (REP[LUNG - 1] != null)
            {

                raddoppiaVettore();
                REP[INDEX++] = element;

            }
            else
            {
                REP[INDEX++] = element;
            }
        }
        public void remove(string elemento)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.remove", this);
            int i = 0;
            while (i < INDEX)
            {
                if (elemento == REP[i])
                    removeAt(i, true);
                else
                    i++;
            }
        }
        public void removeAt(int posiz, bool ord)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.removeAt", this);
            if (INDEX == LUNG / 2)
            {
                dimezzaVettore();
            }
            if (ord == false)
            {
                if (posiz >= 0 && posiz < INDEX)
                {
                    if (INDEX == posiz)
                    {

                        REP[posiz] = null;
                        INDEX--;

                    }
                    else
                        REP[posiz] = null;
                }
            }
            else
            {
                for (int i = posiz; i < INDEX - 1; i++)
                {
                    REP[i] = REP[i + 1];
                }
                REP[INDEX - 1] = null;
                INDEX--;
            }
        }
        public void clear()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.clear", this);
            REP = null;
            REP = new string[1];
            INDEX = 0;
            LUNG = 1;
        }
        public string elementAt(int i)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.elementAt", this);
            return REP[i];
        }
        public int count()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.count", this);
            int eld = 0;
            for (int i = 0; i < length(); i++)
            {
                if (REP[i] != null)
                {
                    eld++;
                }
            }
            return eld;
        }
        public int length()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.length", this);
            return LUNG;
        }
    }
}
