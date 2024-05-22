internal class Program {
    static void Main() {
        Garbage garbage = new();
        garbage.Greetings();
        GC.Collect();
        Console.ReadKey();
    }
}

class Garbage {
    public Garbage() {
        //
    }
    public void Greetings()
    {
        System.Console.WriteLine("Hello Squidward");
    }
}