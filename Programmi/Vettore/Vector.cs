using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vettore_dinamico
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
            while (i < INDEX) //se I è maggiore del indice, vuoldire che non ha trovato l'elemento
            {
                if (elemento == REP[i]) //se trova l'elemento lo toglie
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
                REP[posiz] = null;
                for (int i = posiz; i < INDEX - 1; i++)
                {
                    REP[i] = REP[i + 1];
                }
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
            //conta quanti elementi ci sono nel vdettore, non semplice perche quando si usa removeat e si mette
            //l'ordinamento in falso, l'indice non dirà piu quanti elementi ci sono nel vettore
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
        //public void ordine() //metodo temporaneo, usato per rimettere apposto il vettore dopo aver usato il metodo 
        //removeat con l'ordinamento a falso
        //{
        //    int d = 0;
        //    int tmpind = 0;
        //    while (d < REP.Length)
        //    {
        //        if (REP[d] != null)
        //        {
        //            tmpind++;
        //        }
        //        else
        //        {
        //            break;
        //        }
        //        d++;
        //    }
        //    for (int i = tmpind; i < REP.Length - 1; i++)
        //    {
        //        if (i <= INDEX)
        //        {
        //            REP[i] = REP[i + 1];
        //            REP[i + 1] = null;
        //        }

        //    }

        //}
        public int length()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Vector.length", this);
            return LUNG;
        }
        public string guarda() //metodo temporaneo per vedere cosa ce dentro il vettore
        {
            string rip = "INDEX: " + INDEX + "\r\nLUNG: " + LUNG + "\r\n";
            for (int i = 0; i < REP.Length; i++)
            {
                rip = rip + Convert.ToString(REP[i] + " ");
            }
            rip = rip + "\r\n";
            return rip;
        }
    }
}

