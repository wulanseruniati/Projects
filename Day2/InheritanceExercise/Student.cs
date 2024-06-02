public class Student : Person {
    public string? schoolName;
    public void Studying()
    {
        Console.WriteLine("Currently studying.");
    }

    //override method of person
    public new void Walking()
    {
        Console.WriteLine("Walking to school.");
    }

}