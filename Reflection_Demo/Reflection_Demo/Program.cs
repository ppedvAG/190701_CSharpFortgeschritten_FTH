using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Reflection_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //// Reflection

            //object o1 = 1234;
            //Type objectType = o1.GetType();
            //Console.WriteLine(objectType);

            //// Zur Laufzeit instanzen erstellen:

            //var instanz = Activator.CreateInstance(objectType);

            //Console.WriteLine(instanz);
            //Console.WriteLine(instanz.GetType());

            // DLL zur Laufzeit laden

            Assembly lib = Assembly.LoadFrom("MeineLib.dll");

            Type taschenrechnerType = lib.GetType("MeineLib.Taschenrechner"); // Variante: Name ist bekannt
            object instanz = Activator.CreateInstance(taschenrechnerType);

            // ohne Interface:
            var methodInfo = taschenrechnerType.GetRuntimeMethod("Add", new Type[] { typeof(int), typeof(int) });

            var result = methodInfo.Invoke(instanz, new object[] { 12, 5 });
            Console.WriteLine(result);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }
    }
}
