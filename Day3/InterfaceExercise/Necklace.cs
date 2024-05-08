public class Necklace : Jewellery, IRepository, IValidation, IExport {
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

    public Dictionary<int,string> ShowData() {
        //later on this shall fetch the data from the database
        Dictionary<int, string> necklaceRecord = new Dictionary<int, string> ();
        necklaceRecord.Add(1,"Necklace 1");
        necklaceRecord.Add(2,"Necklace 2");
        return necklaceRecord;
    }

    public int[] GetLocator(int necklaceIdId) {
        //Console.WriteLine("Validating the completeness input of ring data..");
        //ceritanya lookup database
        return [10,1];
    }
    public void CheckRedundancyData<T1,T2>(T1 tableName, T2 necklaceId) {
        Console.WriteLine("Checking the redundancy of necklace id " + necklaceId + " of table " + tableName);
    }

    public void ExportingToExcel() {
        Console.WriteLine("Exporting necklace data to excel..");
    }
    public void ExportingToPDF() {
        Console.WriteLine("Exporting necklace data to pdf..");
    }

    public void ExportingToNotepad() {
        //
        FileInfo f1 = new FileInfo(@"D:\Bootcamp10\Projects\Day3\OutputNecklace.txt");
        FileStream fsToWrite = f1.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(fsToWrite);
        Dictionary<int, string> necklaceRecord = new Dictionary<int, string> ();
        necklaceRecord.Add(1,"Necklace 1");
        necklaceRecord.Add(2,"Necklace 2");
        foreach(KeyValuePair<int,string> kvp in necklaceRecord) {
            sw.WriteLine("The necklace id {0} stands for {1}", kvp.Key, kvp.Value);
        }
        sw.Close();
        fsToWrite.Close();
    }
}