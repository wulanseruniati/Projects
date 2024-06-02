internal class Program
{
    private static void Main(string[] args)
    {
        //instantiate object of class Calculator
        Calculator clc = new Calculator();
        try
        {
            bool isEqual = clc.AreEqual<double>(10.5, 20.5);
        
            if (isEqual)
            {
                System.Console.WriteLine("Both are equal");
            }
            else
            {
                System.Console.WriteLine("Both are not equal");
            }
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e);
        }
        int x = 1;
        int y = 3;
        //calling swap
        Swapper.Swap<int>(ref x, ref y);
        System.Console.WriteLine(x); //3
        System.Console.WriteLine(y); //1
    }
}
