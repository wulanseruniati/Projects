using System;
using System.Threading.Tasks;
class Program
{
    static async Task Main() {
        // Task task1 = Task.Run(() => System.Console.WriteLine("2"));
        // Task task2 = Task.Run(() => System.Console.WriteLine("Hello world"));
        // //Task.WhenAll(task1,task2);
        // Task.WaitAll(task1,task2); //block main thread
        // System.Console.WriteLine("Finished");
        Task task1 = Task.Run(async () => {
            await Task.Delay(2000);
            System.Console.WriteLine("Task1");
        });
        Task task2 = Task.Run(async () => {
            await Task.Delay(2000);
            System.Console.WriteLine("Task2");
        });
        Task completedTask = await Task.WhenAny(task1,task2);
        System.Console.WriteLine("First completed task "+(completedTask == task1 ? "Task 1" : "Task 2"));
    }
}