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

            GenerischerStack<string> stringStack = new GenerischerStack<string>();

            stringStack.Push("Hallo Welt");
            //stringStack.Push(12);
            Console.WriteLine(stringStack.Pop());

            MachEtwas("Hallo Welt - Methode");
            MachEtwas(123);
            MachEtwas(stringStack);


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }


        public static void MachEtwas<T>(T item)
        {
            Console.WriteLine($"Ich mache etwas mit : {item}");
        }
    }
}
