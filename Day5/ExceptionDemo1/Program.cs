using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;

public static class Program
{
    public static void Main()
    {
        //format exception
        string a = "naa27";
        try
        {
            System.Console.WriteLine(int.Parse(a));
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        //divided by zero exception
        int x = 10, y = 0;
        try
        {
            System.Console.WriteLine(x / y);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        //index out of range exception
        int[] someArray = { 1, 2, 3, 4 };
        try
        {
            System.Console.WriteLine(someArray[4]);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        //null reference exception
        string nama = null;
        try
        {
            System.Console.WriteLine(nama.Length);
        }
        catch (System.Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        //stack overflow
        try {
            Run();
        }
        catch (StackOverflowException e)
        {
            System.Console.WriteLine(e.Message);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }

        static void Run() {
            Run();
        }
    }
}