using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Konto
    {
        public Konto(decimal kontostand)
        {
            Kontostand = kontostand;
            buchungnummer = 1;
        }

        private static int buchungnummer;
        public decimal Kontostand { get; private set; }

        public void Einzahlen(decimal betrag)
        {
            buchungnummer++;
            Console.WriteLine($"[{buchungnummer}] Einzahlen wird gestartet: Alter Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
            Kontostand += betrag;
            Console.WriteLine($"[{buchungnummer}] Einzahlen erfolgreich: Neuer Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
        }
        public void Abheben(decimal betrag)
        {
            buchungnummer++;
            Console.WriteLine($"[{buchungnummer}] Abheben wird gestartet: Alter Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
            Kontostand -= betrag;
            Console.WriteLine($"[{buchungnummer}] Abheben erfolgreich: Neuer Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
        }


    }
}
