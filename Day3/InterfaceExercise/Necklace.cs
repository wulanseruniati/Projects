public class Necklace : Jewellery, IRepository {
    public int chainQty {get; set;}
    public double chainWeight {get; set;}

    public int necklaceId {get; set;}

    //overloading two parameters
    public Necklace(int chainQty, double chainWeight)
    {
        this.chainQty = chainQty;
        this.chainWeight = chainWeight;
    }    

    //overloading three parameters
    public Necklace(int chainQty, double chainWeight, int necklaceId)
    {
        this.chainQty = chainQty;
        this.chainWeight = chainWeight;
        this.necklaceId = necklaceId;
    }

    //override the abstract method
    public override void Assembly()
    {
        Console.WriteLine("Assembly the chains");
    }

    //override the parent method
    public override double CalculateWeight(double chainWeight, int chainQty) {
        return chainQty * chainWeight;
    }

    //implementing method from interface
    public void CreateData() {
        Console.WriteLine("Generating new necklace id..");
    }
    public void UpdateData(int necklaceId) {
        Console.WriteLine("Done updating the necklace id " + necklaceId);
    }
}