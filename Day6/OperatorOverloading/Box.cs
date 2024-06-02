public class Box {
    public int Length {get; set;}
    public int Width {get; set;}

    public Box(int length, int width) {
        Length = length;
        Width = width;
    }

    //operator overloading
    public static Box operator + (Box box1, Box box2) {
        int length = box1.Length + box2.Length;
        int width = box1.Width + box2.Width;
        Box box = new Box(length, width);
        return box;
    }
}