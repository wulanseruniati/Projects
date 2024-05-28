class Program {
    static async Task Main() {
        System.Console.WriteLine("Main thread started");
        Task task1;
        Task task2 = null;
        task1 = Task.Run(async() =>
        {
            System.Console.WriteLine("Task 1 started");
            await Task.Delay(1000);
            System.Console.WriteLine("Task 1 waiting for task 2");
            await task2;
        });
        task2 = Task.Run(async() =>
        {
            System.Console.WriteLine("Task 2 started");
            await Task.Delay(1000);
            System.Console.WriteLine("Task 2 waiting for task 1");
            await task1;
        });
        await Task.WhenAll(task1,task2);
        System.Console.WriteLine("All tasks completed");
    }
}