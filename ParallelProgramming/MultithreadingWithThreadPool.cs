using System;
using System.Collections.Generic;
using System.Text;

namespace ParallelProgramming
{
    static class MultithreadingWithThreadPool
    {
        // Rather than finding the optimal number of threads ourselves, 
        // we can leave it to the Common Language Runtime (CLR). 
        // The CLR has an algorithm to determine the optimal number 
        // based on the CPU load at any point in time. It maintains 
        // a pool of threads, known as the ThreadPool

        // Advantages, disadvantages, and when to avoid using ThreadPool
        // Advantages:
        // 
        // - Threads can be utilized to free up the main thread.
        // - Threads are created and maintained in an optimal way by CLR.
        //
        // Disadvantages:
        // 
        // - With more threads, the code becomes difficult to debug and maintain.
        // - We need to do exception handling inside the worker method as any 
        //   unhandled exception can result in the program crashing.
        // - Progress reporting, cancellations, and completion logic need to be written from scratch.
        //
        // Avoid ThreadPool:
        // 
        // - When we need a foreground thread.
        // - When we need to set an explicit priority to a thread.
        // - When we have long-running or blocking tasks. Having a large number of blocked threads 
        //   in the pool will prevent new tasks from starting due to the limited number of threads 
        //   that are available per process in ThreadPool.
        // - If we need STA threads since ThreadPool threads are MTA by default.
        // - If we need to dedicate a thread to a task by providing it a distinct identity since 
        //   we cannot name a ThreadPool thread.
        public static void Start()
        {
            // Sólo un hilo principal. Bloquea el hilo en el loop
            Console.WriteLine("Thread Queue Start Execution!!!");
            CreateThreadUsingThreadPool();
            Console.WriteLine("Finish Execution");
            Console.ReadLine();
        }

        private static void CreateThreadUsingThreadPool()
        {
            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(PrintNumber10Times));
        }

        private static void PrintNumber10Times(object state)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.Write(1);
            }
            Console.WriteLine();
        }
    }
}
