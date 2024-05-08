public abstract class Shape {
    public abstract void Drawing();

    public void ChangeColor(string color) {
        Console.WriteLine("Color changed to "+ color);
    }
}