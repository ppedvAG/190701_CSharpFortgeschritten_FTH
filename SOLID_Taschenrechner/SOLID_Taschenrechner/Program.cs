using ppedv.SOLID_Taschenrechner.Domain.Interfaces;
using ppedv.SOLID_Taschenrechner.Logik;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SOLID_Taschenrechner
{
    class Program
    {
        // Bootstrapping => Alles konfigurieren und initialisieren
        // IoC - Container (Unity, Autofac, CastleWindsor)
        static void Main(string[] args)
        {
            // Alle Assemblies im Plugin-Ordner laden
            if(! Directory.Exists(@".\Plugins"))
                Directory.CreateDirectory(@".\Plugins");

            foreach (string file in Directory.GetFiles(@".\Plugins").Where(x => (Path.GetExtension(x) == ".dll" || Path.GetExtension(x) == ".exe")))
            {
                Assembly.LoadFrom(file); // jede .dll laden
            }

            var alleRechenarten = AppDomain.CurrentDomain.GetAssemblies()
                                                         .Where(x => x.FullName.StartsWith("ppedv.SOLID_Taschenrechner.Logik"))
                                                         .SelectMany(x => x.GetTypes())
                                                         .Where(x => typeof(IRechenart).IsAssignableFrom(x) &&
                                                                     x.IsInterface == false && x.IsAbstract == false)
                                                         .Select(x => (IRechenart)Activator.CreateInstance(x))
                                                         .ToArray();


            if(alleRechenarten.Length == 0)
            {
                Console.WriteLine(@"Keine Rechnenarten im Ordner '\bin\debug\Plugins' gefunden");
                Console.ReadKey();
                return;
            }

            var rechner = new ModulRechner(alleRechenarten);

            var parser = new RegexParser();
            new KonsolenUI(parser,rechner).Start();

            // Übung:
            // Neue DLL erstellen (.NET Standard - Projekt):
            // "PaidFeatures"
            // Implementierung der Rechenarten "Multiplikation" und "Division"
            // -> in das Programm einbauen
        }
    }
}
