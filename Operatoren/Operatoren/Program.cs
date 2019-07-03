using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoren
{
    class Program
    {
        static void Main(string[] args)
        {
            Bruch b1 = new Bruch(1, 2);
            Bruch b2 = new Bruch(1, 4);

            Bruch ergebnis = b1 * b2;
            Bruch ergebnis2 = b1 / b2;

            Bruch ergebnis3 = b1 * 3;

            Console.WriteLine($"Ergebnis: {ergebnis.Zähler}/{ergebnis.Nenner}");
            Console.WriteLine($"Ergebnis: {ergebnis2.Zähler}/{ergebnis2.Nenner}");
            Console.WriteLine($"Ergebnis: {ergebnis3.Zähler}/{ergebnis3.Nenner}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
