internal class Program
{
    private static void Main(string[] args)
    {
        Operation my = new Operation(Calculator.Add);
        my += Calculator.Multiply;
        my.Invoke(2,3);
        System.Console.WriteLine("Setelah dikurangi method add");
        //minus add
        my -= Calculator.Add;
        my.Invoke(2,5);
    }
}