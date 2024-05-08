internal class Program
{
    private static void Main(string[] args)
    {
        double circleArea = Calculator.CalculateCircleArea(14.0);
        Console.WriteLine("The area of circle is : " + circleArea);

        double addResult = Calculator.Add(10.0, 14.0);
        Console.WriteLine("The add operation result is : " + addResult);

        Console.WriteLine("The substraction result is : " + Calculator.Substract(30.0, 14.0));

        Console.WriteLine("The multiplication result is : " + Calculator.Multiplication(10.0, 2.0));

        try
        {
            try
            {
                Console.WriteLine("The divided by result is : " + Calculator.DividedBy(28.0, 14.0));
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Divisor shouldn't be zero. Error Message: " + ex);
            }
        }
        catch
        {
            Console.WriteLine("Other errors");
        }


        CalculatorNonStatic clc = new();
        double circleArea1 = clc.CalculateCircleArea(28.0);
        Console.WriteLine("NonStatic. The area of circle is : " + circleArea1);

        string msg = MethodExtensions.ToUpper("Good Morning");
        Console.WriteLine(msg);
    }
}