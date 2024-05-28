class Program
{
    static void Main()
    {
        FileManager fileManager = new();
        Thread thread = new Thread(() =>
        {
            try
            {
                Thread.Sleep(1000);
                Task<string> outputLog = Task.Run(() => fileManager.Read("../logPlayerr.txt"));
                System.Console.WriteLine(outputLog.Result);
                ExceptionMaker();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Exception caught: {e.Message}");
            }
        });
        thread.Start();
        thread.Join();
        //task
        try
        {
            Task task = Task.Run(() => ExceptionMaker());
            Task<string> outputLog = Task.Run(() => fileManager.Read("../logPlayerr.txt"));
            System.Console.WriteLine(outputLog.Result);
            Task.WaitAll(task, outputLog);
        }
        catch (AggregateException e)
        {
            System.Console.WriteLine(e.Message);
        }
    }

    static void ExceptionMaker()
    {
        throw new FormatException("Exception thrown from Exception Maker");
    }
}