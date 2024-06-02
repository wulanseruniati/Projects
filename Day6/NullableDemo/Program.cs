internal class Program
{
    private static void Main(string[] args)
    {
        int? a = null;
        if(a.HasValue)
        {
            System.Console.WriteLine($"a is : {a}");
        }
        else {
            System.Console.WriteLine("a doesn't have value");
        }
        //generic
        Nullable<int> nullableInt = null;
        System.Console.WriteLine(nullableInt);

        //compare
    }
}