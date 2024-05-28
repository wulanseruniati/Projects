class Program
{
    static int counter = 0;
    static object key = new();
    static async Task Main()
    {
        Task task1 = CounterAsync();
        Task task2 = CounterAsync();

        await Task.WhenAll(task1, task2);
        System.Console.WriteLine("Final counter : " + counter);
        //await CounterAsync();
    }
    static async Task CounterAsync()
    {
        System.Console.WriteLine("Starting counter...");
        lock (key)
        {
            for (int i = 0; i < 10; i++)
            {
                counter++;
                System.Console.WriteLine("Counter from " + Thread.CurrentThread.ManagedThreadId + " : " + i);
            }
        }
        await Task.Delay(100);
    }
}