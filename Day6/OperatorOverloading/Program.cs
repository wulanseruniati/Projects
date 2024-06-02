internal class Program
{
    private static void Main(string[] args)
    {
        //instantiate
        Box box1 = new(4, 4);
        Box box2 = new(5, 5);
        Box box3 = box1 + box2;
        System.Console.WriteLine(box3.Length);
        System.Console.WriteLine(box3.Width);
        Point point1 = new Point(5, 3);
        Point point2 = new Point(1, 2);
        //operator overloading minus
        Point point3 = point1 - point2;
        System.Console.WriteLine(point3.X);
        System.Console.WriteLine(point3.Y);
    }

    public struct Point
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public static Point operator - (Point p1, Point p2 )
        {
            return new Point(p1.X - p2.X, p1.Y - p2.Y);
        }
    }
}