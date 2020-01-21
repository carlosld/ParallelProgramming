using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;

namespace ParallelProgramming
{
    static class MultithreadingWithBackgroundWorker
    {
        // BackgroundWorker provides an abstraction over raw threads, 
        // which gives more control and options to the user. The best 
        // part about using BackgroundWorker is that it uses an 
        // Event-Based Asynchronous Pattern (EAP), which means it is 
        // able to interact with the code more efficiently than raw threads.

        // Advantages and disadvantages of using BackgroundWorker
        // Advantages:
        // 
        // - Threads can be utilized to free up the main thread.
        // - Threads are created and maintained in an optimal way by the ThreadPool class's CLR.
        // - Graceful and automatic exception handling.
        // - Supports progress reporting, cancellation, and completion logic using events.
        // Disadvantage:
        // - With more threads, the code becomes difficult to debug and maintain. 

        public static void Start()
        {
            Console.WriteLine("BackgroundWorker Start Execution!!!");
            var backgroundWorker = new BackgroundWorker();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += SimulateServiceCall;
            backgroundWorker.ProgressChanged += ProgressChanged;
            backgroundWorker.RunWorkerCompleted += RunWorkerCompleted;
            backgroundWorker.RunWorkerAsync();

            Console.WriteLine("To Cancel Worker Thread Press C.");
            while (backgroundWorker.IsBusy)
            {
                if (Console.ReadKey(true).KeyChar == 'C')
                {
                    backgroundWorker.CancelAsync();
                }
            }
        }

        // This method executes when the background worker finishes 
        // execution
        private static void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error != null)
            {
                Console.WriteLine(e.Error.Message);
            }
            else
                Console.WriteLine($"Result from service call is { e.Result }");
        }

        // This method is called when background worker want to 
        // report progress to caller
        private static void ProgressChanged(object sender,
          ProgressChangedEventArgs e)
        {
            Console.WriteLine($"{e.ProgressPercentage}% completed");
        }

        // Service call we are trying to simulate
        private static void SimulateServiceCall(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;
            StringBuilder data = new StringBuilder();

            //Simulate a streaming service call which gets data and 
            //store it to return back to caller
            for (int i = 1; i <= 100; i++)
            {
                //worker.CancellationPending will be true if user 
                //press C
                if (!worker.CancellationPending)
                {
                    data.Append(i);
                    worker.ReportProgress(i);
                    Thread.Sleep(100);
                    //Try to uncomment and throw error
                    //throw new Exception("Some Error has occurred");
                }
                else
                {
                    //Cancels the execution of worker
                    worker.CancelAsync();
                }
            }
            e.Result = data;
        }
    }
}
