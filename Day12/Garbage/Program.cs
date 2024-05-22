internal class Program {
    static void Main() {
        Garbage garbage = new();
        //garbage.Greetings();
        if (garbage != null) ((IDisposable)garbage).Dispose();
        //garbage.Dispose();
        GC.Collect();
        //Console.ReadKey();
    }
}

class Garbage : IDisposable{
    public Garbage() {
        //
    }
    public void Greetings()
    {
        System.Console.WriteLine("Hello Squidward");
    }

    public void Dispose()
    {
        Dispose();
        GC.SuppressFinalize(this);
    }

    ~Garbage() // 
    {
        System.Console.WriteLine("Bye Garbage");
    }
} 