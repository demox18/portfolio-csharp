using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestioneLibri
{
    internal class Vector
    {
        private object[] REP;
        private int INDEX;
        private int LUNG;
        public Vector(int l)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.Vector", this);

            LUNG = l;
            REP = new object[l];

        }
        public void add(object element)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.add", this);

            if (REP[REP.Length - 1] != null)
            {
                object[] tempREP = new object[REP.Length * 2];
                for (int i = 0; i < REP.Length; i++)
                {
                    tempREP[i] = REP[i];
                }
                tempREP[INDEX++] = element;
                REP = tempREP;
            }
            else
            {
                REP[INDEX++] = element;
            }
        }
        public void remove()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.remove", this);

            REP[--INDEX] = 0;
            if (INDEX == REP.Length / 2)
            {
                object[] tempREP = new object[REP.Length / 2];
                for (int i = 0; i < INDEX; i++)
                {
                    tempREP[i] = REP[i];
                }
                REP = tempREP;
            }

        }
        public void removeAt(int posiz, bool ord)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.removeAt", this);
            if (ord == false)
            {
                if (posiz >= 0 && posiz < INDEX)
                {
                    REP[posiz] = null;
                    INDEX--;
                }
            }
            else
            {
                for (int i = posiz; i < INDEX - 1; i++)
                {
                    REP[i] = REP[i + 1];
                }
                REP[--INDEX] = null;
            }
        }
        public void clear()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.clear", this);
            for (int i = 0; i < REP.Length; i++)
            {
                REP[i] = 0;
            }
        }
        public object elementAt(int i)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.elementAt", this);
            return REP[i];
        }
        public int count()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.count", this);
            int eld = 0;
            for (int i = 0; i < REP.Length; i++)
            {
                if (REP[i] != null)
                {
                    eld++;
                }
            }
            return eld;
        }
        public void ordine()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.ordine", this);
            int d = 0;
            int tmpind = 0;
            while(d < REP.Length)
            {
                if (REP[d] != null)
                { 
                    tmpind++;
                }
                else
                {
                    break;
                }
                d++;
            }
            for (int i = tmpind; i < REP.Length - 1; i++)
            {
                if (i <= INDEX)
                {
                    REP[i] = REP[i + 1];
                    REP[i + 1] = null;
                }
                    
            }
            
        }
        public string guarda()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.guarda", this);
            string rip = "";
            for (int i = 0; i < REP.Length; i++)
            {
                rip = rip + Convert.ToString(REP[i] + " ");
            }
            return rip;
        }
    }
}
