using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Pre und Postincrement
            //int zahl1 = 42;

            //int zahl2 = zahl1++;

            //Console.WriteLine(zahl1);
            //Console.WriteLine(zahl2);

            //Console.WriteLine("---Pre----");

            //zahl1 = 42;

            //zahl2 = ++zahl1;

            //Console.WriteLine(zahl1);
            //Console.WriteLine(zahl2); 
            #endregion

            #region ObjectStack
            //ObjectStack os = new ObjectStack();

            //os.Push("12");
            //os.Push(12345);
            //os.Push(12.5);
            //os.Push("Hallo Welt");

            //os.Push("größer !!!");

            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());
            //Console.WriteLine(os.Pop());

            // Console.WriteLine(os.Pop()); // Exception
            #endregion

            #region Generischer Stack
            //GenerischerStack<string> stringStack = new GenerischerStack<string>();

            //stringStack.Push("Hallo Welt");
            ////stringStack.Push(12);
            //Console.WriteLine(stringStack.Pop());

            //MachEtwas("Hallo Welt - Methode");
            //MachEtwas(123);
            //MachEtwas(stringStack); 
            #endregion

            //Dictionary<string, string> EU = new Dictionary<string, string>();
            //EU.Add("Österreich", "Wien");
            //EU.Add("Deutschland", "Berlin");
            //EU.Add("Tschechei", "Wien");
            //EU.Add("Slowakei", "Wien");
            //EU.Add("Ungarn", "Wien");
            //EU.Add("Polen", "Warschau");
            //EU.Add("Frankreich", "Paris");
            //EU.Add("Belgien", "Brüssel");
            //EU.Add("Italien", "Rom");

            //if(EU.ContainsKey("Großbritannien"))
            //    Console.WriteLine(EU["Großbritannien"]);
            //else
            //    Console.WriteLine("Gibts nimma");


            GenerischerStack<string> meinStack = new GenerischerStack<string>();

            meinStack.Push("Hallo");
            meinStack.Push("Welt");
            meinStack.Push("!");

            meinStack[0] = "Auf Wiedersehen";

            Console.WriteLine(meinStack[0]);

            // Übung:
            // Eigenes Dictionary erfinden:
            // class MeinDictionary<TKey,TValue>
            // -> Constraints: TKey muss ein Wertetyp sein
            // ->              TValue muss IDisposable (z.B. Person erfinden, die IDisposable ist)
            // Features:
            // Add(TKey key, TValue value)
            // indexer 
            // Intern: tkey[] und tvalue[]


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }


        public static void MachEtwas<T>(T item)
        {
            Console.WriteLine($"Ich mache etwas mit : {item}");
        }
    }
}
