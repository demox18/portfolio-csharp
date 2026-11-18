using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestioneLibri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.Form1", this);
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.Form1_Load", this);
            
        }
        Biblioteca Vlibri = new Biblioteca();
        string basestring = "Libri:\r\n";
        string stringtmp = "";
        private void BML_Click(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.BML_Click", this);
            Vlibri.AggiungiLibro(TBNomeLibro.Text);
            Vlibri.OrdinaLibri();
            stringtmp = "";
            for (int i = 0; i < Vlibri.ContaLibri(); i++)
            {
                stringtmp = stringtmp + $"{i + 1}) " + Vlibri.VisualizzaLibroIn(i) + "\r\n";    
            }
            ListaLibri.Text = basestring + stringtmp;
        }

        private void BTL_Click(object sender, EventArgs e)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Form1.BTL_Click", this);
            int sttmp = Convert.ToInt32(TBIndice.Text);
            Vlibri.RimuoviLibroAt(sttmp-1);
            Vlibri.OrdinaLibri();
            stringtmp = "";
            for (int i = 0; i < Vlibri.ContaLibri(); i++)
            {
                stringtmp = stringtmp + $"{i + 1}) " + Vlibri.VisualizzaLibroIn(i) + "\r\n";
            }
            ListaLibri.Text = basestring + stringtmp;
        }
    }
}
