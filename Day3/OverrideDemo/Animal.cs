public class Animal {
    //virtual method : to be overriden by the child classes
    public virtual void MakeSound() {
        Console.WriteLine("Animal Make Sound");
    }

    public void Eating() {
        Console.WriteLine("Animal Eating");
    }
}