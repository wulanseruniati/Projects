public class Ring : Jewellery, IRepository {
    public int componentQty {get; set;}
    public double componentWeight {get; set;}

    public int ringId {get; private set;}

    //overloading two parameters
    public Ring(int componentQty, double componentWeight)
    {
        this.componentQty = componentQty;
        this.componentWeight = componentWeight;
    }    

    //overloading three parameters
    public Ring(int componentQty, double componentWeight, int ringId)
    {
        this.componentQty = componentQty;
        this.componentWeight = componentWeight;
        this.ringId = ringId;
    }

    //override the abstract method
    public override void Assembly()
    {
        Console.WriteLine("Soldering the ring");
    }

    //override the parent method
    public override double CalculateWeight(double componentWeight, int componentQty) {
        return componentQty * componentWeight;
    }

    //implementing method from interface
    public void CreateData() {
        Console.WriteLine("Generating new ring id..");
    }
    public void UpdateData(int ringId) {
        Console.WriteLine("Done updating the ring id " + ringId);
    }
}