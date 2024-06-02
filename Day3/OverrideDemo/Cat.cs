public class Cat : Animal {
    //override the method
    public override void MakeSound() {
        base.MakeSound();
        Console.WriteLine("Meow");
    }

    public new void Eating() {
        Console.WriteLine("Ittadakimasu");
    }
}