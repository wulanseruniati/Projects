using System.Runtime.InteropServices;

public static class Program
{
    public static void Main()
    {
        Human hm = new();
        hm.Balance = 10000;
        System.Console.WriteLine("Balance 1 : " + hm.Balance);
        hm.Balance = -11;
        System.Console.WriteLine("Balance 2 : " + hm.Balance);
    }
}