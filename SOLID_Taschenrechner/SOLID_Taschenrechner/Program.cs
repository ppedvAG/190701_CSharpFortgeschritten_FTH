using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping => Alles konfigurieren und initialisieren
        static void Main(string[] args)
        {
            new KonsolenUI().Start();
        }
    }

    public struct Formel
    {
        public Formel(int operand1, int operand2, string rechenoperator)
        {
            Operand1 = operand1;
            Operand2 = operand2;
            Rechenoperator = rechenoperator;
        }

        public int Operand1 { get; set; }
        public int Operand2 { get; set; }
        public string Rechenoperator { get; set; }
    }

    public class StringSplitParser
    {
        public Formel Parse(string input)
        {
            string[] teile = input.Split();
            int zahl1 = Convert.ToInt32(teile[0]);
            string op = teile[1];
            int zahl2 = Convert.ToInt32(teile[2]);

            return new Formel(zahl1, zahl2, op);
        }
    }

    public class SimplerRechner
    {
        public int Berechne(Formel formel)
        {
            if (formel.Rechenoperator == "+")
                return formel.Operand1 + formel.Operand2;
            else if (formel.Rechenoperator == "-")
                return formel.Operand1 - formel.Operand2;
            else
                throw new InvalidOperationException("Der Rechenoperator ist unbekannt");
        }
    }

    public class KonsolenUI
    {
        public void Start()
        {
            Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
            string eingabe = Console.ReadLine();

            // Parsen
            StringSplitParser parser = new StringSplitParser();
            Formel f = parser.Parse(eingabe);

            // Rechnen
            SimplerRechner rechner = new SimplerRechner();
            int ergebnis = rechner.Berechne(f);

            Console.WriteLine($"Das Ergebnis ist: {ergebnis}");

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
