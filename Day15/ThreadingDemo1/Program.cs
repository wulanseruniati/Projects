using System.Text;

class Program
{
    static void Main()
    {
        //single threading - ga gitu kepake
        Thread thread = new( () => Printer());
        Thread thread2 = new Thread(Printer2);
        Thread thread3 = new Thread(Printer3);
        Thread thread4 = new Thread(Printer4);
        Thread thread5 = new Thread(Printer5);
        thread.Name = "Yusa";
        thread.IsBackground=true;
        thread.Priority = ThreadPriority.Normal; //ga disarankan ya
        thread.Start();
        thread2.Start();
        thread3.Start();
        thread4.Start();
        thread5.Start();
        System.Console.WriteLine("Program finished");
    }

    static void Printer()
    {
        System.Console.WriteLine("Printer");
    }

    static void Printer2()
    {
        System.Console.WriteLine("Printer2");
    }

    static void Printer3()
    {
        System.Console.WriteLine("Printer3");
    }

    static void Printer4()
    {
        System.Console.WriteLine("Printer4");
    }
    static void Printer5()
    {
        System.Console.WriteLine("Printer5");
    }

    static void BuildString()
    {
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        StringBuilder text = new();
        for (int i = 0; i < 5; i++)
        {
            text.Append("a");
            text.Append("b");
            text.Append("c");
        }
        System.Console.Write(text);
        Console.WriteLine("Thread t has ended!");
    }
    static void BuildString2()
    {
        System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId);
        StringBuilder text = new();
        for (int j = 0; j < 5; j++)
        {
            for (int i = 0; i < 5; i++)
            {
                text.Append("a");
                text.Append("b");
                text.Append("c");
            }
            System.Console.WriteLine(text);
        }
        Console.WriteLine("Thread t2 has ended!");
    }
}