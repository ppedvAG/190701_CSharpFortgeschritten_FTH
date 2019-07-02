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

    public class RegexParser : IParser
    {
        public Formel Parse(string input)
        {
            Regex r = new Regex(@"(\d+)\s*([+\-*/])\s*(\d+)",RegexOptions.Compiled);
            var result = r.Match(input);

            if (result.Success)
            {
                Formel formel = new Formel();

                formel.Operand1 = Convert.ToInt32(result.Groups[1].Value);
                formel.Rechenoperator = result.Groups[2].Value;
                formel.Operand2 = Convert.ToInt32(result.Groups[3].Value);

                return formel;
            }
            else
                throw new FormatException("Ungültiges Formelformat");
        }
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

    public class ModulRechner : IRechner
    {
        public ModulRechner(params IRechenart[] rechenarten)
        {
            this.rechenarten = rechenarten;
        }
        private readonly IRechenart[] rechenarten;

        public int Berechne(Formel formel)
        {
            var rechenart = rechenarten.FirstOrDefault(x => x.Rechenoperator == formel.Rechenoperator);
            if (rechenart != null)
                return rechenart.Berechne(formel.Operand1, formel.Operand2);
            else
                throw new InvalidOperationException($"Operator '{formel.Rechenoperator}'ist leider unbekannt");
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
