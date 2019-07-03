using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parallel_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] durchgänge = { 10_000, 50_000, 100_000, 250_000, 500_000, 1_000_000, 5_000_000, 10_000_000, 100_000_000 };

            //// JIT -> Damit unten bereits alles kompiliert ist 
            //ForTest(10_000);
            //ParallelTest(10_000);

            //Stopwatch watch = new Stopwatch();
            //for (int i = 0; i < durchgänge.Length; i++)
            //{
            //    Console.WriteLine($"-------- Durchgang: {durchgänge[i]} --------");
            //    watch.Restart();
            //    ForTest(durchgänge[i]);
            //    watch.Stop();

            //    Console.WriteLine($"For: {watch.ElapsedMilliseconds}ms");

            //    watch.Restart();
            //    ParallelTest(durchgänge[i]);
            //    watch.Stop();

            //    Console.WriteLine($"Parallel: {watch.ElapsedMilliseconds}ms");
            //}


            // Foreach
            string[] data = { "Tom Ate", "Anna Nass", "Peter Silie", "Franz Ose", "Martha Pfahl", "Axel Schweiß", "Rosa Schlüpfer", "Anna Bolika", "Frank N Stein", "Albert Tross", "Klara Fall", "Rainer Zufall" };
            Parallel.ForEach(data, item =>
             {
                 Console.WriteLine(item);
             });

            // Invoke
            // Parallel.Invoke(Machwas1, Machwas2, Machwas3);

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        public static void ForTest(int durchgänge)
        {
            double[] elemente = new double[durchgänge];
            for (int i = 0; i < durchgänge; i++)
            {
                elemente[i] = Math.Pow(i, 0.333333) * Math.Sqrt(Math.Tan(i / 2)) - Math.PI * Math.Log10(i * 10); 
            }
        }

        public static void ParallelTest(int durchgänge)
        {
            double[] elemente = new double[durchgänge];
            // Maximal 2 Kerne
            Parallel.For(0, durchgänge,new ParallelOptions { MaxDegreeOfParallelism = 2 }, i =>
             {
                 elemente[i] = Math.Pow(i, 0.333333) * Math.Sqrt(Math.Tan(i / 2)) - Math.PI * Math.Log10(i * 10);
             });
        }
    }
}
