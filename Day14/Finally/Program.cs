class Program
{
    static void Main()
    {
        try {
            string a="3a";
            int b = int.Parse(a);
        }
        catch(FormatException e)
        {
            System.Console.WriteLine("Format exception ");
        }
        finally {
            System.Console.WriteLine("Program closed");
        }
    }
}