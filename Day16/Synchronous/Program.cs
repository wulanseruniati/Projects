class Program
{
    static async Task Main()
    {
        await Asynchronous();
        Synchronous();
        await SemiAsynchronous();
    }

    static void Synchronous() {
        DoWork("eat");
        DoWork("drink");
    }

    static async Task SemiAsynchronous() {
        DoWork("eat");
        DoWork("drink");
        await Asynchronous();
        DoWork("sleep");
    }

    static async Task Asynchronous() {
        Task eat = DoWorkAsync("eat");
        Task drink = DoWorkAsync("drink");

        await Task.WhenAll(eat,drink);
    }

    static void DoWork(string work) {
        System.Console.WriteLine($"{work} started");
        Thread.Sleep(2000);
        System.Console.WriteLine($"{work} finished");
    }

    static async Task DoWorkAsync(string work) {
        System.Console.WriteLine($"{work} is started");
        await Task.Delay(2000);
        System.Console.WriteLine($"{work} is finished");
    }
}