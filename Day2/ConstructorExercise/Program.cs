using mobil;
internal class Program
{
    private static void Main(string[] args)
    {
        //create object, call the constructor of 3 parameters
        Car raceCar1 = new Car("Race Car", "Bugatti", false);
        raceCar1.startingEngine();
        raceCar1.speed = 60.0;
        //calling the method of one parameter
        double timeNeeded = raceCar1.returnTimeNeeded(120.0);
        Console.WriteLine("Time needed for " + raceCar1.brand + " : " + timeNeeded + " hour");

        //create object, call the constructor of 4 parameters
        Car raceCar2 = new Car("Race Car", "Ferarri",false,50.0);        
        raceCar2.startingEngine();
        //calling the method of two parameters
        double timeNeeded2 = raceCar1.returnTimeNeeded(120.0, true);
        Console.WriteLine("Time needed for " + raceCar2.brand + " : " + timeNeeded2 + " hour");
    }
}