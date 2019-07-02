using ppedv.SOLID_Taschenrechner.Logik;
using ppedv.SOLID_Taschenrechner.Logik.FreeFeatures;
using ppedv.SOLID_Taschenrechner.Logik.PaidFeatures;
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

            var parser = new RegexParser();
            var rechner = new ModulRechner(new Addition(), new Subtraktion(), new Multiplikation(), new Division()) ;
            new KonsolenUI(parser,rechner).Start();

            // Übung:
            // Neue DLL erstellen (.NET Standard - Projekt):
            // "PaidFeatures"
            // Implementierung der Rechenarten "Multiplikation" und "Division"
            // -> in das Programm einbauen
        }
    }
}
