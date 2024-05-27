class Program
{
    static object lockObject = new object();
    static void Main()
    {
        Thread thread1 = new(() => PrintChar());
        Thread thread2 = new(() => PrintChar());
        thread1.Start();
        thread2.Start();
    }

    static void PrintChar()
    {
        lock (lockObject)
        {
            string strArray = "Hi Programmer";
            for (int i = 0; i < strArray.Length; i++)
            {
                System.Console.Write(strArray[i]);
                Thread.Sleep(TimeSpan.FromSeconds(0.1));
            }
            System.Console.WriteLine(" ");
        }
    }
}