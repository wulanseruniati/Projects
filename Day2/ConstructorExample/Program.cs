using Kucing;
internal class Program
{
    private static void Main(string[] args)
    {
        //dengan constructor:
        Cat caty = new Cat("Whiskas","Caty");
        Cat catyta = new Cat("Chicken","Catyta");
        //satu parameter
        Cat catytu = new Cat("Fish");
        //bisa juga:
        //Cat caty = new();
        //tanpa constructor:
        //caty.favoriteFood = "whiskas";

        caty.Eat();
        catyta.Eat();
        catytu.Eat();
        

    }
}
