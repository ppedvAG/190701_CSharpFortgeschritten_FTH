using ppedv.SOLID_Taschenrechner.Domain;
using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using System;

namespace SOLID_Taschenrechner
{
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
