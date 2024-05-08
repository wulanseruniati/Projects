class Program
{
    static void Main(string[] args) {
        Calculator calc = new();
        //chooses the method which required the integer as parameter at the runtime
        int hasil = calc.Add(1,2);
        Console.WriteLine(hasil);
        //chooses the method which required the double as parameter at the runtime
        double result = calc.Add(1.5,10.5);
        Console.WriteLine(result);
    }
}

public class Calculator {
    //overloading the same quantity of parameter but different type
    public int Add(int a, int b) {
        return a + b;
    }

    public double Add(double a, double b) {
        return a + b;
    }
}