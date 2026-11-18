using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pila
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.Form1", this);
            InitializeComponent();
        }
        Pila vett_pila = new Pila();

        private void lbdisplay_SelectedIndexChanged(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.lbdisplay_SelectedIndexChanged", this);
            
        }
        void refresh_display(Pila tmpvet) //faccio una funzione dove mi aggiorna la lista
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.refresh_display", null);
            lbdisplay.Items.Clear(); //svuoto la lista
            for (int i = tmpvet.Count()-1; i >= 0; i--) 
            {
                lbdisplay.Items.Add(tmpvet.Peek(i)); //riempio la lista di nuovi dati con un ciclo
            }
        }

        private void bPop_Click(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.bPop_Click", this);
            if (vett_pila.Peek(0) != null) //controllo se nella pila ce un elemento, se non ce non fa niente.
            {
                tbpop.Text = vett_pila.Peek(vett_pila.Count() - 1);// prendo l'ultimo elemento che ho messo e lo metto nella textbox
                vett_pila.Pop();//tolgo l'ultimo elemento
                refresh_display(vett_pila);//aggiorno la lista
            }
        }

        private void bPush_Click_1(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.bPush_Click_1", this);
            vett_pila.Push(tbpush.Text);//prendo l'elemnto che ha scritto l'utente nel textbox e lo aggiungo nel vettore
            refresh_display(vett_pila);//aggiorno la lista
        }

        private void bclear_Click(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.bclear_Click", this);
            vett_pila.Clear();//pulisco il vettore
            refresh_display(vett_pila);//aggiorno la lista
        }
    }
}
