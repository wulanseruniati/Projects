public class Circle : Shape, IShape {
    public void Draw() {
        Console.WriteLine("Drawing from interface");
    }

    public override void Drawing() {
        Console.WriteLine("Drawing from abstract");
    }
}