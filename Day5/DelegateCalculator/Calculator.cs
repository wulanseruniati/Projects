public delegate void Operation(int x, int y);

public static class Calculator
{
    public static void Multiply(int x, int y)
    {
        System.Console.WriteLine(x*y);
    }
    public static void Add(int x, int y)
    {
        System.Console.WriteLine(x+y);
    }
}