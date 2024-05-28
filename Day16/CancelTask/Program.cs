using System.Diagnostics;

class Program
{
    static async Task Main()
    {
        CancellationTokenSource cts = new();
        CancellationToken token = cts.Token;

        CancellationTokenSource cancellationTokenSource = new CancellationTokenSource(5000);
        try
        {
            await FetchingLargeData(cancellationTokenSource.Token);
        }
        catch (TaskCanceledException ex)
        {
            Console.WriteLine($"{ex.Message}");
        }

        Task task = DoWorkAsync(token);
        System.Console.WriteLine("Press C to cancel");
        if (Char.ToLower(Console.ReadKey().KeyChar) == 'c')
        {
            cts.Cancel();
        }

        try
        {
            await task;
            System.Console.WriteLine("Operation completed");
        }
        catch (OperationCanceledException)
        {
            System.Console.WriteLine("Operation cancelled");
        }
    }
    static async Task DoWorkAsync(CancellationToken token)
    {
        for (int i = 0; i <= 10; i++)
        {
            token.ThrowIfCancellationRequested();
            System.Console.WriteLine($"Work in progress {i * 10} %");
            await Task.Delay(2000);
        }
    }
    static async Task FetchingLargeData(CancellationToken token)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        //read from a large notepad file
        FileManager fileManager = new();
        System.Console.WriteLine(fileManager.Read("../logPlayer.txt"));
        await Task.Delay(10000);
        if (token.IsCancellationRequested)
        {
            throw new TaskCanceledException();
        }
        stopwatch.Stop();
        Console.WriteLine($"LongRunningTask Took {stopwatch.ElapsedMilliseconds / 1000.0} Seconds for Processing");
    }
}