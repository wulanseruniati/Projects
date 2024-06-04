public class Necklace : IRepository {
    public int chainQty {get; set;}
    public double chainWeight {get; set;}

    public int necklaceId {get; private set;}

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

    //implementing method from interface
    public void CreateData() {
        Console.WriteLine("Generating new necklace id..");
    }
    public void UpdateData(int necklaceId) {
        Console.WriteLine("Done updating the necklace id " + necklaceId);
    }

    public Dictionary<int,string> FetchData() {
        //later on this shall fetch the data from the database
        Dictionary<int, string> necklaceRecord = new Dictionary<int, string> ();
        necklaceRecord.Add(1,"Necklace 1");
        necklaceRecord.Add(2,"Necklace 2");
        return necklaceRecord;
    }
}