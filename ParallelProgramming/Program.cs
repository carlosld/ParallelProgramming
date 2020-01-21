using System;

namespace ParallelProgramming
{
    public class Program
    {
        // Multithreading.
        // Parallel execution of code in .NET is achieved through multithreading
        static void Main(string[] args)
        {
            MultithreadingWithThreads.Start();
            MultithreadingWithThreadPool.Start();
            MultithreadingWithBackgroundWorker.Start();
        }

       
    }
}
