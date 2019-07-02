using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Thread_Demo
{
    class SemaphoreZähler
    {
        private static Semaphore semaphore = new Semaphore(5,5);
        private static int zähler;

        public void MachWas()
        {
            semaphore.WaitOne();

            zähler++;
            Console.WriteLine(zähler);
            zähler--;

            semaphore.Release();
        }
    }
}
