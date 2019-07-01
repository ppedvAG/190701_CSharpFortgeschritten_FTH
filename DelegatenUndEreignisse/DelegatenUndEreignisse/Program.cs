using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatenUndEreignisse
{
    class Program
    {
        // Delegate-Type
        //     delegate Rückgabewert Name(parameter)
        public delegate void MeinDelegat();
        public delegate int Rechenoperation(int z1, int z2);

        static void Main(string[] args)
        {
            // Variante 1: delegate

            //A();
            //B();
            //C(12);

            //MeinDelegat del = new MeinDelegat(A);
            //del += B;
            //del();

            #region Anwendungsfall: ohne Delegate
            //Console.WriteLine("Bitte geben Sie eine Zahl ein:");
            //int zahl1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Bitte geben Sie eine zweite Zahl ein:");
            //int zahl2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Bitte geben Sie den Rechenoperator ein");
            //string op = Console.ReadLine();

            //int ergebnis = 0;
            //if (op == "+")
            //    ergebnis = zahl1 + zahl2;
            //else if (op == "-")
            //    ergebnis = zahl1 - zahl2;
            //// ....

            //Console.WriteLine($"Das Ergebnis ist {ergebnis}"); 
            #endregion
            #region Anwendungsfall mit Delegate
            //Console.WriteLine("Bitte geben Sie eine Zahl ein:");
            //int zahl1 = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("Bitte geben Sie eine zweite Zahl ein:");
            //int zahl2 = Convert.ToInt32(Console.ReadLine());

            //Console.WriteLine("Bitte geben Sie den Rechenoperator ein");
            //string op = Console.ReadLine();

            //Rechenoperation operation = null;
            //if (op == "+")
            //    operation = Add; // rechenart
            //else if (op == "-")
            //    operation = Sub;
            //// ....

            //Console.WriteLine($"Das Ergebnis ist {operation(zahl1,zahl2)}"); 
            #endregion

            #region Delegate-Typen:
            //// Action<T> => Alles ohne Rückgabe (void)

            //// Action<int> meineAction = new Action<int>(C);
            //Action<int> meineAction =C;
            //Action aUndb = A;
            //aUndb += B;
            //// Action erlaubt bis zu 16 Parameter

            //// Func<T> => Alles MIT Rückgabe
            //Func<int, int, int> rechnung = Sub;

            //// Spezieller: EventHandler
            //EventHandler handler = new EventHandler(button1_click); 
            #endregion


            Button b1 = new Button();
            b1.ClickEvent += MeinButton_Click;

            b1.ClickEvent += Logger;

            b1.Click();
            b1.Click();

            // b1.ClickEvent = null;        // absolut verboten !

            b1.Click();

            b1.ClickEvent -= Logger;

            b1.Click();
            b1.Click();

            // Null Conditional Operator, C# 6
           //  b1.ClickEvent?.Invoke(null,null);        // verboten

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        private static void Logger(object sender, EventArgs e)
        {
            Console.WriteLine($"[{DateTime.Now.ToLongTimeString()}] Button wurde geklickt");
            // ((Button)sender).ClickEventHandler -= Logger;
        }

        private static void MeinButton_Click(object sender, EventArgs e)
        {
            Console.Beep();
            Console.WriteLine("*click*");
        }

        private static void button1_click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        static int Add(int z1, int z2) => z1 + z2;
        static int Sub(int z1, int z2) => z1 - z2;


        static void A()
        {
            Console.WriteLine("A");
        }
        static void B()
        {
            Console.WriteLine("B");
        }
        static void C(int zahl)
        {
            Console.WriteLine($"C{zahl}");
        }
    }
}
