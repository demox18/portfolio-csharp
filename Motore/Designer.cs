// Al posto dei Form1.Designer.cs originali: creano gli stessi controlli con gli stessi nomi e scritte
// e collegano gli stessi gestori dei clic.
using System.Windows.Forms;

namespace Pila
{
    public partial class Form1 : Form
    {
        private ListBox lbdisplay = new() { Name = "lbdisplay" };
        private TextBox tbpush = new() { Name = "tbpush" };
        private Button bPush = new() { Name = "bPush", Text = "push" };
        private Button bPop = new() { Name = "bPop", Text = "pop" };
        private Button bclear = new() { Name = "bclear", Text = "clear" };
        private TextBox tbpop = new() { Name = "tbpop" };
        private Label label1 = new() { Text = "elemento che vuoi aggiungere:" };
        private Label label2 = new() { Text = "elemento che hai tolto:" };

        private void InitializeComponent()
        {
            Text = "Form1";
            bPush.Click += new System.EventHandler(this.bPush_Click_1);
            bPop.Click += new System.EventHandler(this.bPop_Click);
            bclear.Click += new System.EventHandler(this.bclear_Click);
        }
    }
}

namespace GestioneLibri
{
    public partial class Form1 : Form
    {
        private Button BML = new() { Name = "BML", Text = "metti libro" };
        private Button BTL = new() { Name = "BTL", Text = "Togli libro" };
        private TextBox TBNomeLibro = new() { Name = "TBNomeLibro" };
        private TextBox TBIndice = new() { Name = "TBIndice" };
        private Label ListaLibri = new() { Name = "ListaLibri", Text = "Libri:" };

        private void InitializeComponent()
        {
            Text = "Form1";
            BML.Click += new System.EventHandler(this.BML_Click);
            BTL.Click += new System.EventHandler(this.BTL_Click);
        }
    }
}
