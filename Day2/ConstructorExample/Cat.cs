namespace Kucing
{
    public class Cat
    {
        string? color;
        string? species;
        int age;

        public string? favoriteFood;
        public string? catName;

        public Cat(string favoriteFood)
        {
            this.favoriteFood = favoriteFood;
        }

        //overloading constructor with 2 parameters
        public Cat(string favoriteFood, string catName)
        {
            this.favoriteFood = favoriteFood;
            this.catName = catName;
        }

        public void Eat()
        {
            Console.WriteLine(catName + " eat " + favoriteFood);
        }

        public void printInfo (string catName)
        {
            Console.WriteLine(catName);
        }
        public void printInfo (string catName, string favoriteFood)
        {
            Console.WriteLine(catName);
            Console.WriteLine(favoriteFood);
        }
    }
}