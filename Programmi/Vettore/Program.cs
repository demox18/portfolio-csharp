using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vettore_dinamico
{
    //demox - 4B
    internal class Program
    {
        public static async Task Avvio(string[] args)
        {
            using var __traccia = global::Demox.Motore.Traccia.Entra("Program.Avvio", null);
            Vector VETTORE = new Vector();
            VETTORE.add("1");
            VETTORE.add("2");
            VETTORE.add("3");
            //VETTORE.add(4);
            //VETTORE.add(5);
            //VETTORE.add(6);
            //VETTORE.add(7);
            string stra = VETTORE.guarda();
            Console.WriteLine(stra);
            //Console.WriteLine(stra);
            //VETTORE.remove();
            //VETTORE.remove();
            //VETTORE.remove();
            //stra = VETTORE.guarda();
            //Console.WriteLine(stra);
            //VETTORE.add(5);
            //VETTORE.add(6);
            //VETTORE.add(7);
            //VETTORE.removeAt(2, true);
            //stra = VETTORE.guarda();
            //Console.WriteLine(stra);
            //VETTORE.clear();

            VETTORE.removeAt(1, true);
            stra = VETTORE.guarda();
            Console.WriteLine(stra);

            VETTORE.add("4");
            stra = VETTORE.guarda();
            Console.WriteLine(stra);

            VETTORE.removeAt(1, true);
            stra = VETTORE.guarda();
            Console.WriteLine(stra);

            VETTORE.add("5");
            stra = VETTORE.guarda();
            Console.WriteLine(stra);

            await Console.ReadLine();
        }
    }
}
