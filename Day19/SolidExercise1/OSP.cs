public interface IShape {
    public double CalculateArea();
}
public class Rectangle : IShape{
    public double Width {get; private set;}
    public double Height {get; private set;}
    public double CalculateArea() {
        return Width*Height;
    }
}
public class Circle : IShape {
    public double Radius {get; private set;}
    public double CalculateArea() {
        return Math.PI*Radius*Radius;
    }
}
public class Triangle : IShape{
    public double Base {get; private set;}
    public double Height {get; private set;}
    public double CalculateArea() {
        return 0.5*Base*Height;
    }
}

public class PrintShape {
    public void PrintShapeResult(IShape shape) {
        System.Console.WriteLine("The calculation result is : "+shape.CalculateArea());
    }
}