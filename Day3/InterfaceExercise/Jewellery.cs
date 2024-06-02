public abstract class Jewellery {
    protected string? color;

    //abstract method, the assembly process of every jewellery is different
    public abstract void Assembly();

    //calculate method, some jewellery could implement it differently
    public virtual double CalculateWeight(double componentWeight, int componentQty) {
        return componentQty * componentWeight;
    }

    //polishing process is the same for every jewellery
    public void Polishing() {
        Console.WriteLine("Polishing the jewellery");
    }
}