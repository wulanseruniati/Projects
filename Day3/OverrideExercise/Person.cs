public class Person : Creature {
    public string? name;
    public bool isMarried;

    //overriding abstract method
    public override void Walking()
    {
        Console.WriteLine("Walking");
    }

    public virtual double PredictWeight(double dailyCaloryConsumed)
    {
        return dailyCaloryConsumed / height * 5;
    }
}