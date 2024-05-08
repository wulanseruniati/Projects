public class Pensioner : Person {
    public double pensionMoneyLeft;
    public void CountingMoney()
    {
        Console.WriteLine("Counting sweet pension money.");
    }

    public override double PredictWeight(double dailyCaloryConsumed)
    {
        return dailyCaloryConsumed / height * 4;
    }
}