using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
            string eingabe = Console.ReadLine();

            string[] teile = eingabe.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            string op = teile[1];
            int zahl2 = Convert.ToInt32(teile[2]);

            int ergebnis = 0;
            if (op == "+")
                ergebnis = zahl1 + zahl2;
            else if (op == "-")
                ergebnis = zahl1 - zahl2;

            Console.WriteLine($"Das Ergebnis ist: {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
