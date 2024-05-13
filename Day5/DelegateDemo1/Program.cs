internal class Program
{
    private static void Main(string[] args)
    {
        MyDelegate my = new MyDelegate(DelegateClass.Print);
        my += DelegateClass.Run;
        my.Invoke();
        //my(); -- maaf kurang thread safety
    }    
}
/*public delegate void MyDelegate();
internal class Program
{
    private static void Main(string[] args)
    {
        MyDelegate my = new MyDelegate(Print);
        my.Invoke();
        my();
    }

    static void Print() {
            System.Console.WriteLine("morning..");
        }
}*/