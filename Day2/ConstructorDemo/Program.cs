using automotive;
using vehicle;
using kitchen;

internal class Program
{
    private static void Main(string[] args)
    {
        Speed speed = new Speed(25.5f);
        Wheel wheel = new Wheel("Offroad",2023,"Dunlop");
        Engine engine = new Engine("Supra",1200,"Toyota");
        Cake cake = new Cake("Rose Brand");
        Car car = new Car("Black","Toyota",2,engine,wheel,speed);
        wheel.PrintAttribute();
        car.PrintAttribute(car.color,car.brand,car.numDoor);
    }
}