internal class Program
{
    private static void Main(string[] args)
    {
        void Display(params string[] numb) {
            foreach(string items in numb) {
                System.Console.WriteLine(items);
            }
        }
        Calculator clc = new Calculator();
        Display("Satu","Dua");
        System.Console.WriteLine(clc.Add(1,2,3,4,5));
        StringCalculator clcc = new();
        System.Console.WriteLine(clcc.Add("1","2","3","4","5"));
    }
}