using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQ_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region LINQ
            //List<Person> personen = new List<Person>
            //{
            //    new Person{Vorname="Tom",Nachname="Ate",Alter=10,Kontostand=100},
            //    new Person{Vorname="Anna",Nachname="Nass",Alter=20,Kontostand=200},
            //    new Person{Vorname="Peter",Nachname="Silie",Alter=30,Kontostand=300000},
            //    new Person{Vorname="Martha",Nachname="Pfahl",Alter=40,Kontostand=-4100},
            //    new Person{Vorname="Franz",Nachname="Ose",Alter=50,Kontostand=123555},
            //    new Person{Vorname="Man",Nachname="Heimer",Alter=60,Kontostand=7654},
            //    new Person{Vorname="Albert",Nachname="Tross",Alter=70,Kontostand=98765},
            //    new Person{Vorname="Axel",Nachname="Schweiß",Alter=80,Kontostand=-87765100},
            //    new Person{Vorname="Anna",Nachname="Bolika",Alter=90,Kontostand=99999},
            //    new Person{Vorname="Claire",Nachname="Grube",Alter=100,Kontostand=1000000000},
            //};

            ////// Situation: Von jeder Person den Vornamen in ein Array hineinschreiben
            ////string[] alleVornamen = new string[personen.Count];
            ////for (int i = 0; i < personen.Count; i++)
            ////{
            ////    alleVornamen[i] = personen[i].Vorname;
            ////}

            ////// Situation: Von jeder Person den Vornamen in ein Array hineinschreiben, die einen negativen Kontostand hat
            ////string[] alleVornamenMitNegativemKontostand = new string[personen.Count];
            ////for (int i = 0; i < personen.Count; i++)
            ////{
            ////    if(personen[i].Kontostand < 0)
            ////        alleVornamen[i] = personen[i].Vorname;
            ////}

            ////// Situation: Von jeder Person den Vornamen in ein Array hineinschreiben mit negativem Kontostand sortiert nach alter absteigend


            //// SELECT -> Wert herausnehmen
            //string[] alleVornamen = personen.Select(SelektorFunktion)
            //                                .ToArray();

            //string[] alleVornamen2 = personen.Select(person => person.Vorname)
            //                                 .ToArray();

            //// WHERE -> Filtern
            //List<string> alleVornamenMitNegativemKontostand = personen.Where(x => x.Kontostand < 0)
            //                                                          .Select(x => x.Vorname)
            //                                                          .ToList();

            //// ORDERBY / ORDERBYDescending -> Sortieren

            //var personenMitNegativemKontostand = personen.Where(x => x.Kontostand < 0)
            //                                             .OrderByDescending(x => x.Alter)
            //                                             .ToList();

            //// FIRST, LAST, FirstOrDefault :Elemente herausnehmen

            //// finde die reichste person
            //Person dringendAnrufen = personen.OrderByDescending(x => x.Kontostand)
            //                                 .First();

            //// X Elemente herausnehmen: TAKE
            //// fünf reichsten personen
            //Person[] reich = personen.OrderByDescending(x => x.Kontostand)
            //                         .Take(5)
            //                         .ToArray();

            //// Auslassen : Skip
            //// Berechnungen: Min/Max/Sum/Avarage

            //// durchschnittlichen Kontostand aller Personen ohne schulden haben

            //decimal durchschnitt = personen.Where(x => x.Kontostand > 0)
            //                               // .Select(x => x.Kontostand)
            //                               .Average(x => x.Kontostand); // eingebautes Select

            //// Any: hat ein element diese bedingung erfüllt ?
            //if (personen.Any(x => x.Kontostand < 0))
            //    ; //es gibt diese Person 

            //// https://code.msdn.microsoft.com/101-LINQ-Samples-3fb9811b 
            #endregion

            // Erweiterungsmethoden

            string text = "Hallo Welt !";
            Console.WriteLine(text.Umdrehen());
            Console.WriteLine(Erweiterungsmethoden.Umdrehen(text)); // Compiler schreibt das zu dieser Zeile um

            Console.WriteLine(123.Verdoppeln());

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }


        //private static string SelektorFunktion(Person arg)
        //{
        //    return arg.Vorname;
        //}
        private static string SelektorFunktion(Person arg) => arg.Vorname;
        //{
        //    return arg.Vorname;
        //}

        private static int Addieren(int z1, int z2) =>  z1 + z2;
        //{
        //    return z1 + z2;
        //}
    }
}
