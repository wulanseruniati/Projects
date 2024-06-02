using automotive;
namespace vehicle;

public class Car {
    public string color;
    public string brand;
    public int numDoor;
    public Engine engine;
    public Wheel wheel;
    public Speed speed;
    
    public Car(string color, string brand, int numDoor, Engine engine, Wheel wheel, Speed speed)
    {
        this.color = color;
        this.brand = brand;
        this.numDoor = numDoor;
        this.engine = engine;
        this.wheel = wheel;
        this.speed = speed;
    }

    public void PrintAttribute(string color, string brand, int numDoor)
    {
        Console.WriteLine($"The car's color is {color}");
        Console.WriteLine($"The car's brand is {brand}");
        Console.WriteLine($"The car's number of door is {numDoor}");
    }
}