using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Konto
    {
        public Konto(decimal kontostand)
        {
            Kontostand = kontostand;
            buchungnummer = 0;
        }

        private static object lockObject = new object();
        private static int buchungnummer;
        public decimal Kontostand { get; private set; }

        public void Einzahlen(decimal betrag)
        {
            Monitor.Enter(lockObject);

            buchungnummer++;
            Console.WriteLine($"[{buchungnummer}] Einzahlen wird gestartet: Alter Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
            Kontostand += betrag;
            Console.WriteLine($"[{buchungnummer}] Einzahlen erfolgreich: Neuer Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");

            Monitor.Exit(lockObject);
        }
        public void Abheben(decimal betrag)
        {
            lock (lockObject)
            {
                buchungnummer++;
                Console.WriteLine($"[{buchungnummer}] Abheben wird gestartet: Alter Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
                Kontostand -= betrag;
                Console.WriteLine($"[{buchungnummer}] Abheben erfolgreich: Neuer Kontostand: {Kontostand:C2}, Betrag: {betrag:C2}");
            }
        }


    }
}
