using System;

namespace ParallelProgramming
{
    // The simplest and easiest way of creating threads is via the 
    // Thread class, which is defined in the System.Threading 
    // namespace. This approach has been used since the arrival of 
    // .NET version 1.0 and it works with .NET core as well. To 
    // create a thread, we need to pass a method that the thread 
    // needs to execute. The method can either be parameter-less or parameterized.

    // Advantages and disadvantages of threads
    // Advantages
    // 
    // - Threads can be utilized to free up the main thread.
    // - Threads can be used to break up a task into smaller units that can be executed concurrently.
    //
    // Disadvantages
    // 
    // - With more threads, the code becomes difficult to debug and maintain.
    // - Thread creation puts a load on the system in terms of memory and CPU resources.
    // - We need to do exception handling inside the worker method as any unhandled exceptions can result in the program crashing.

    static class MultithreadingWithThreads
    {
        public static void Start()
        {
            // Sólo un hilo principal. Bloquea el hilo en el loop
            Console.WriteLine("One thread Start Execution!!!");

            PrintNumber10Times();
            Console.WriteLine("Finish Execution");
            Console.ReadLine();

            // Un hilo diferente para la tarea. Bloquea el hilo en el loop
            Console.WriteLine("Un hilo diferente. Start Execution!!!");

            //Using Thread without parameter
            CreateThreadUsingThreadClassWithoutParameter();
            Console.WriteLine("Finish Execution");
            Console.ReadLine();

            // Un hilo diferente para la tarea. Bloquea el hilo en el loop
            Console.WriteLine("Un hilo diferente pero con parámetros. Start Execution!!!");
            //Using Thread with parameter
            CreateThreadUsingThreadClassWithParameter();
            Console.WriteLine("Finish Execution");
            Console.ReadLine();
        }

        private static void CreateThreadUsingThreadClassWithoutParameter()
        {
            // The simplest and easiest way of creating threads is via the Thread class, 
            // which is defined in the System.Threading namespace. This approach has been 
            // used since the arrival of .NET version 1.0 and it works with .NET core as well. 
            // To create a thread, we need to pass a method that the thread needs to execute.

            System.Threading.Thread thread;
            thread = new System.Threading.Thread(new
             System.Threading.ThreadStart(PrintNumber10Times));
            thread.Start();
        }

        private static void CreateThreadUsingThreadClassWithParameter()
        {
            System.Threading.Thread thread;
            thread = new System.Threading.Thread(new
             System.Threading.ParameterizedThreadStart(PrintNumberNTimes));
            thread.Start(12);
        }

        private static void PrintNumber10Times()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }

        private static void PrintNumberNTimes(object times)
        {
            int n = Convert.ToInt32(times);
            for (int i = 0; i < n; i++)
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }
    }
}
