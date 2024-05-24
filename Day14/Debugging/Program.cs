using System.Runtime.InteropServices;
public class Calculator
{
    public int Multiplying(int a, int b)
    {
        return a * b;
    }
}
public class Program
{
    static void Main()
    {
        Calculator calc = new();
        int result = calc.Multiplying(2, 3);
        System.Console.WriteLine(result);
        #if RELEASE
                Console.WriteLine("Release mode");
        #else
                Console.WriteLine("Debug mode");
        #endif

    }
}