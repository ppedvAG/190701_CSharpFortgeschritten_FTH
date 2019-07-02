using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
            var rechner = new ModulRechner(new Addition());
            new KonsolenUI(parser,rechner).Start();
        }
    }

    public class Addition : IRechenart
    {
        public string Rechenoperator => "+";

        public int Berechne(params int[] operanden) => operanden.Sum();
    }
    public class Subtraktion : IRechenart
    {
        public string Rechenoperator => "-";

        public int Berechne(params int[] operanden) => operanden[0] - operanden.Skip(1).Sum();
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
