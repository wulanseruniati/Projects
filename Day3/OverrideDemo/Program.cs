internal class Program
{
    private static void Main(string[] args) {
        //create a new object of class cat
        Cat caty = new Cat();
        caty.MakeSound();

        //explicit casting
        ((Animal)caty).MakeSound();

        int x = 10;
        //implicit casting
        double y = x;

        double a = 100.0;
        //ga bisa impilicit
        //int b = a;
        
        //explicit casting
        int b = (int)a;
    }
}