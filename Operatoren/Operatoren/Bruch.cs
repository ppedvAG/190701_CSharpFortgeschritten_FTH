using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Operatoren
{
    class Bruch
    {
        public Bruch(int zähler, int nenner)
        {
            Zähler = zähler;
            Nenner = nenner;
        }

        public int Zähler { get; set; }
        public int Nenner { get; set; }

        public static Bruch operator*(Bruch links, Bruch rechts)
        {
            return new Bruch(links.Zähler * rechts.Zähler, links.Nenner * rechts.Nenner);
        }
        public static Bruch operator *(Bruch links, int rechts)
        {
            return new Bruch(links.Zähler * rechts, links.Nenner * 1);
        }
        public static Bruch operator /(Bruch links, Bruch rechts)
        {
            return new Bruch(links.Zähler * rechts.Nenner, links.Nenner * rechts.Zähler);
        }

        // Operatoren:
        // +,-,*,/,%, <<, >>, &, |, ^
        // +=, -= etc.. 

        // Vergleichsoperatoren
        // Achtung: Paarweise implementieren
        // <,> <=,>=, ==, !=

    }
}
