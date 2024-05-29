using System;
using System.Threading;

namespace SemaphoreDemo
{
    class Program
    {
        public static Semaphore semaphore = null;
        public static Semaphore semaphore2 = null;

        static void Main(string[] args)
        {
            try
            {
                //Try to Open the Semaphore if Exists, if not throw an exception
                semaphore = Semaphore.OpenExisting("SemaphoreDemo");
            }
            catch (Exception Ex)
            {
                //If Semaphore not Exists, create a semaphore instance
                //Here Maximum 2 external threads can access the code at the same time
                semaphore = new Semaphore(2, 2, "SemaphoreDemo");
            }

            Console.WriteLine("External Thread Trying to Acquiring");
            semaphore.WaitOne();
            //This section can be access by maximum two external threads: Start
            Console.WriteLine("External Thread Acquired");
            Console.ReadKey();
            //This section can be access by maximum two external threads: End
            semaphore.Release();

            //trying
            try
            {
                semaphore2 = Semaphore.OpenExisting("SemaphoreDemo2");
            }
            catch (Exception Ex)
            {
                //Here Maximum 2 external threads can access the code at the same time
                semaphore2 = new Semaphore(2, 2, "SemaphoreDemo2");
            }
            Task task1 = new Task(PrintMethod);
            Task task2 = new Task(PrintMethod);
            Task task3 = new Task(PrintMethod);
            task1.Start();
            task2.Start();
            task3.Start();
            Task.WaitAll(task1,task2,task3);
        }

        static void PrintMethod()
        {
            System.Console.WriteLine("Background thread : " + Thread.CurrentThread.ManagedThreadId+ " Starting");
            Thread.Sleep(1000);
            semaphore.WaitOne();            
            System.Console.WriteLine("Background thread : " + Thread.CurrentThread.ManagedThreadId+ " Finishing");
            semaphore.Release();
        }
    }
}
