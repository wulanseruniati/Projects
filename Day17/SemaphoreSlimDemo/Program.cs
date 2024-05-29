using System.Threading.Tasks;
using System.Security.AccessControl;
class Program
{
    static SemaphoreSlim semaphore = new(2);
    static async Task Main() {
        Task[] tasks = new Task[10];
        for (int i = 0; i < tasks.Length; i++)
        {
            int index = i;
            tasks[i] = Task.Run(async () => await DoWork(index));
        }
        await Task.WhenAll(tasks);
    }

    static async Task DoWork(int index) {
        System.Console.WriteLine($"Task {index} started");
        await semaphore.WaitAsync();
        await Task.Delay(500);
        System.Console.WriteLine($"Task {index} processing");
        await Task.Delay(500);
        semaphore.Release();
        System.Console.WriteLine($"Task {index} finished");
    }
}