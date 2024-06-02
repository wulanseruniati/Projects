class Program
{
    static void Main()
    {
        /*Task is a background thread!
        Task task1 = new(() => System.Console.WriteLine("Task1"));
        task1.Start();
        //task1.RunSynchronously();
        //Task task2 = Task.Run(() => System.Console.WriteLine("Task2"));
        task1.Wait();
        System.Console.WriteLine(task1.IsCompleted);
        */
        Task task1 = new Task(() =>
        {
            System.Console.WriteLine("T1");
            Thread.Sleep(6000);
            System.Console.WriteLine("Task1 complete");
        });
        Task task2 = new Task(() =>
        {
            System.Console.WriteLine("T2");
            Thread.Sleep(12000);
            System.Console.WriteLine("Task2 complete");
        });
        task1.Start();
        task2.Start();
        System.Console.WriteLine("Task1 running");
        System.Console.WriteLine("Task2 running");
        task1.Wait();
        System.Console.WriteLine("Task1 done");
        task2.Wait();
        System.Console.WriteLine("Task2 done");
    }
}