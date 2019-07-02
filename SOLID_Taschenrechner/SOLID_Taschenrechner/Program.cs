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
            // IoC - Container (Unity, Autofac, CastleWindsor)

            var parser = new StringSplitParser();
            var rechner = new SimplerRechner();
            new KonsolenUI(parser,rechner).Start();
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

    public interface IParser
    {
        Formel Parse(string input);
    }

    public class StringSplitParser : IParser
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

    public interface IRechner
    {
        int Berechne(Formel formel);
    }
    public class SimplerRechner : IRechner
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
        public KonsolenUI(IParser parser, IRechner rechner)
        {
            this.parser = parser;
            this.rechner = rechner;
        }

        private readonly IParser parser;
        private readonly IRechner rechner;

        public void Start()
        {
            bool tryAgain = false;
            do
            {
                Console.WriteLine("Bitte geben Sie die Formel ein:"); // "2 + 2"
                string eingabe = Console.ReadLine();

                // Parsen
                Formel f = parser.Parse(eingabe);

                // Rechnen
                int ergebnis = rechner.Berechne(f);

                Console.WriteLine($"Das Ergebnis ist: {ergebnis}");

                Console.Write("Wollen Sie das Programm beenden ? (q)");
                tryAgain = Console.ReadKey().KeyChar == 'q' ? false : true;
                Console.Clear();
            } while (tryAgain);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
