class Program
{
    static void Main()
    {
        Task<int> task = Task.Run(() =>
        {
            System.Console.WriteLine("Task1 running on thread " + Thread.CurrentThread.ManagedThreadId);
            return new Random().Next(1, 100);
        });

        var tcs = new TaskCompletionSource<int>();
        StartSeparateOperation(tcs);

        // Wait for the task to complete
        var result = tcs.Task.Result;

        // Print the result
        Console.WriteLine("Result of separate operation: {0}", result);

        Task taskForLoop = Task.Run(() =>
        {
            for (int i = 0; i < 10; i++)
            {
                System.Console.WriteLine("+");
                Thread.Sleep(5);
            }
        });
        System.Console.WriteLine(taskForLoop.IsCompleted);
        System.Console.WriteLine(taskForLoop.IsCanceled);
        System.Console.WriteLine(taskForLoop.IsFaulted);
        Task.WaitAll(task, taskForLoop);
        System.Console.WriteLine("Task1 generating random number " + task.Result);
        System.Console.WriteLine(taskForLoop.IsCompleted);
        System.Console.WriteLine(taskForLoop.IsCanceled);
        System.Console.WriteLine(taskForLoop.IsFaulted);
    }

    static void StartSeparateOperation(TaskCompletionSource<int> tcs)
    {
        // simulate a long running operation
        Task.Run(() =>
        {
            System.Console.WriteLine("Separate operation running in thread " + Thread.CurrentThread.ManagedThreadId);
            Thread.Sleep(3000);
            // set the result when the operation is complete
            tcs.SetResult(42);
        });
    }
}