using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Threads
            ////Thread t1 = new Thread(Punkt);
            ////Thread t2 = new Thread(Strich);
            ////Thread t3 = new Thread(new ParameterizedThreadStart(Zeichen));

            ////// Werden beim Schließen der Appliaktion ebenfalls sofort beendet
            ////t1.IsBackground = true;
            ////t1.IsBackground = true;
            ////t3.IsBackground = true;

            ////t1.Start();
            ////t2.Start();
            ////t3.Start('#');

            ////Thread.Sleep(2000);
            ////// Thread beenden
            ////t1.Abort();
            ////// Auf Threads warten
            ////t2.Join();
            ////t3.Join();

            //// ThreadPool
            //// ThreadPool.QueueUserWorkItem(Punkt);
            //// ThreadPool.QueueUserWorkItem(Strich);
            // ThreadPool.QueueUserWorkItem(Zeichen,'@');
            #endregion

            #region Monitor und Lock
            //Console.OutputEncoding = Encoding.Unicode;

            //Konto k1 = new Konto(10_000);

            //for (int i = 0; i < 10; i++)
            //{
            //    ThreadPool.QueueUserWorkItem(ZufälligesKontoUpdate, k1);
            //} 
            #endregion

            #region Mutex
            //Mutex mutex = new Mutex(false, "MeinMutex1234");

            //for (int i = 0; i < 100; i++)
            //{
            //    mutex.WaitOne();

            //    Thread.Sleep(100);
            //    Console.WriteLine(i);

            //    mutex.ReleaseMutex();
            //} 
            #endregion

            SemaphoreZähler zähler = new SemaphoreZähler();

            for (int i = 0; i < 500; i++)
                new Thread(zähler.MachWas).Start();


            Console.WriteLine("---ENDE---");
            Console.ReadKey();
        }

        static void ZufälligesKontoUpdate(object item)
        {
            Konto currentKonto = (Konto)item;
            Random generator = new Random(Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 10; i++)
            {
                if (generator.Next(0, 2) % 2 == 0)
                    currentKonto.Einzahlen(generator.Next(0, 1000));
                else
                    currentKonto.Abheben(generator.Next(0, 1000));
            }
        }

        private static void Zeichen(object arg)
        {
            char zeichen = (char)arg;
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(50);
                Console.Write(zeichen);
            }
        }

        static void Punkt()
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Thread.Sleep(50);
                    Console.Write(".");
                }
            }
            catch (ThreadAbortException)
            {
                // Thread.ResetAbort();
            }
            finally
            {
                // drittressourcen freigeben
            }
            Console.WriteLine("lalala ich mache trotzdem weiter ;)");
        }

        static void Strich()
        {
            for (int i = 0; i < 100; i++)
            {
                Thread.Sleep(100);   // währenddessen kann ein anderer Thread noch was machen
                // Thread.SpinWait() // Alternative, in denen der Kontext nicht gewechselt wird  
                Console.Write("-");
            }
        }
    }
}
