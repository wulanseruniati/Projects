public class Cat : Animal {
    public string color;

    public Cat(int age, string gender, bool isAlive, string color) : base (age, gender, isAlive) {
        this.color = color;
    }
    public void Meow() {
        Console.WriteLine("miaw");
    }
}