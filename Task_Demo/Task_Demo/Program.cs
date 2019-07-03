using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            // Task erstellen:

            #region Tasks ohne Rückgabe
            //Task t1 = new Task(MachEtwas);
            //t1.Start();

            //// .NET 4.0:
            //Task t2 = Task.Factory.StartNew(MachEtwas); // Startet sofort !

            //// .NET 4.5:
            //Task t3 = Task.Run(MachEtwas); // Startet sofort !
            //// => Ist vergleichbar mit:
            //// Task.Factory.StartNew(MachEtwas, CancellationToken.None, TaskCreationOptions.DenyChildAttach, TaskScheduler.Default);
            //// https://docs.microsoft.com/en-us/dotnet/api/system.threading.tasks.taskcreationoptions?f1url=https%3A%2F%2Fmsdn.microsoft.com%2Fquery%2Fdev15.query%3FappId%3DDev15IDEF1%26l%3DEN-US%26k%3Dk(System.Threading.Tasks.TaskCreationOptions);k(TargetFrameworkMoniker-.NETFramework,Version%3Dv4.6.1);k(DevLang-csharp)%26rd%3Dtrue&view=netframework-4.8 
            #endregion

            #region Tasks mit Rückgabe
            //Task<int> t1 = new Task<int>(GibEineZahlZurück);
            //t1.Start();

            //Task<int> t2 = Task.Factory.StartNew(GibEineZahlZurück);

            //Task<int> t3 = Task.Run(GibEineZahlZurück);

            //for (int i = 0; i < 100; i++)
            //{
            //    Thread.Sleep(100);
            //    Console.Write("zZ");
            //}

            //// Auf das Ergebnis zugreifen:
            //Console.WriteLine(t1.Result); // Wartet, wenn der Task noch nicht fertig ist 
            #endregion

            #region Parameter an einen Task übergeben
            //Task t1 = Task.Factory.StartNew(MachWasMitParameter, "MeinParameter");
            //int zahl1 = 42;
            //string text1 = "abcde";

            //Task.Run(() =>
            //{
            //    for (int i = 0; i < 10; i++)
            //    {
            //        Console.WriteLine($"{text1} {zahl1}");
            //    }
            //}); 
            #endregion

            #region Auf Tasks warten
            //Task t1 = Task.Run(() =>
            //{
            //    Thread.Sleep(3000);
            //    Console.WriteLine("Langer Task");
            //});
            //Task t2 = Task.Run(() =>
            //{
            //    Thread.Sleep(6000);
            //    Console.WriteLine("Sehr langer Task");
            //});
            //Task t3 = Task.Run(() =>
            //{
            //    Thread.Sleep(9000);
            //    Console.WriteLine("Puhhh das dauert....");
            //});

            //Thread.Sleep(1000);
            //if(t1.IsCompleted)
            //    Console.WriteLine("Task1 ist fertig");
            //else
            //{
            //    Console.WriteLine("Task1 läuft noch");
            //    t1.ContinueWith(MeinCallback);
            //}

            //Task.WaitAll(t1, t2, t3);
            #endregion

            #region Tasks abbrechen
            //CancellationTokenSource cts = new CancellationTokenSource();

            //Task t1 = Task.Run(() =>
            //{
            //    Console.WriteLine("Ich mache jetzt etwas sehr lange ...");
            //    for (int i = 0; i < 100; i++)
            //    {
            //        //if(cts.Token.IsCancellationRequested) // Polling
            //        //{
            //        //    Console.WriteLine("ich muss leider aufhören :(");
            //        //    break;
            //        //}
            //        // cts.Token.ThrowIfCancellationRequested();

            //        Console.Write('#');
            //        Thread.Sleep(20000);
            //    }
            //    Console.WriteLine("Aufgabe erledigt !");
            //},cts.Token); // Hier gilt das Token nur für das Abbrechen bevor der Task "richtig" startet
            //// Wenn der Task bereits läuft, bewirkt die Angabe des Tokens im Parameter NICHTS !

            //Thread.Sleep(2000);
            //Console.WriteLine("Task wird abgebrochen:");
            //cts.Cancel();
            #endregion

            #region Exceptions in Tasks
            //Task t1 = new Task(() =>
            //{
            //    Thread.Sleep(3000);
            //    throw new DivideByZeroException();
            //});
            //t1.Start();

            //Task t2 = Task.Factory.StartNew(() =>
            //{
            //    Thread.Sleep(5000);
            //    throw new ArgumentException();
            //});

            //Task t3 = Task.Run(() =>
            //{
            //   Thread.Sleep(8000);
            //   throw new FormatException();
            //});

            //try
            //{
            //    Task.WaitAll(t1, t2, t3);
            //}
            //catch (AggregateException ex)
            //{
            //    // Mit foreach durch jede InnerException durchgehen und behandeln
            //}

            //// Suffix:
            //var x1 = 12;    // Int32
            //var x2 = 12U;   // UInt32
            //var x3 = 12.5;  // Double
            //var x4 = 12.5m; // Decimal
            //var x5 = 12L;   // Long
            //var x6 = 12f;   // Float
            //var x7 = 12UL;  // UInt64
            #endregion

            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }




        private static void MeinCallback(Task obj)
        {
            Console.WriteLine("Ich werde ausgeführt wenn der Task1 fertig ist !!!");
        }

        private static void MachWasMitParameter(object arg)
        {
            Console.WriteLine(arg);
        }

        static void MachEtwas()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread.Sleep(100); // intern werden trotzdem Threads genutzt
                Console.WriteLine($"[{Thread.CurrentThread.ManagedThreadId}]Ich mache etwas in diesem Task: {i}");
            }
        }

        static int GibEineZahlZurück()
        {
            Thread.Sleep(8000);
            return 42;
        }
    }
}
