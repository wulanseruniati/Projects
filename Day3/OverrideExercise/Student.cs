public class Student : Person {
    public string? schoolName;
    public void Studying()
    {
        Console.WriteLine("Currently studying.");
    }

    //method overriding
    public override void Walking()
    {
        Console.WriteLine("Walking to school.");
    }

    public override double PredictWeight(double dailyCaloryConsumed)
    {
        return dailyCaloryConsumed / height * 3;
    }

}