public class Employee : Person {
    public string? workplace;
    public void Working()
    {
        Console.WriteLine("Sorry, busy working.");
    }

    //create new method for employee
    public new void Walking()
    {
        Console.WriteLine(name + " is walking to work.");
    }
}