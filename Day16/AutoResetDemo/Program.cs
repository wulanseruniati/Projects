class Program
{
    static AutoResetEvent autoResetEvent = new(true);
    static void Main() {
        Thread thread = new Thread(SomeMethod) {
            Name="New Thread",
            IsBackground = false
        };
        Thread thread1 = new Thread(SomeMethod) {
            Name="Another"
        };
        thread.Start();
        thread1.Start();
        Console.ReadLine();
    }

    static void SomeMethod() {
        System.Console.WriteLine(Thread.CurrentThread.Name + " Starting..");
        autoResetEvent.WaitOne();
        System.Console.WriteLine(Thread.CurrentThread.Name + " Finishing..");
        autoResetEvent.Set();
    }
}