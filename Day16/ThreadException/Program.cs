class Program
{
    static void Main()
    {
        Thread thread = new Thread(() =>
        {
            try
            {
                Thread.Sleep(1000);
                ExceptionMaker();
                ExceptionMaker2();
            }
            catch (Exception e)
            {
                System.Console.WriteLine($"Exception caught: {e.Message}");
            }
        });
        thread.Start();
        thread.Join();
        // System.Console.WriteLine("Finished");

        // //task
        // try
        // {
        //     Task task = Task.Run(() => ExceptionMaker());
        //     Task task2 = Task.Run(() => ExceptionMaker2());
        //     Task.WaitAll(task, task2);
        // }
        // catch (AggregateException e)
        // {
        //     System.Console.WriteLine(e.Message);
        // }
    }

    static void ExceptionMaker()
    {
        throw new FormatException("Exception thrown from Exception Maker");
    }

    static void ExceptionMaker2()
    {
        throw new NullReferenceException("Exception thrown from Exception Maker2");
    }
}