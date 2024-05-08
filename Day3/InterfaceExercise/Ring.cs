public class Ring : Jewellery, IRepository, IValidation, IExport {
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

    public Dictionary<int,string> ShowData() {
        //later on this shall fetch the data from the database
        Dictionary<int, string> ringRecord = new Dictionary<int, string> ();
        ringRecord.Add(1,"Ring 1");
        ringRecord.Add(2,"Ring 2");
        return ringRecord;
    }

    public int[] GetLocator(int ringId) {
        //Console.WriteLine("Validating the completeness input of ring data..");
        //ceritanya lookup database
        return [5,10];
    }
    public void CheckRedundancyData<T1,T2>(T1 tableName, T2 ringId) {
        Console.WriteLine("Checking the redundancy of ring id " + ringId + " of table " + tableName);
    }

    public void ExportingToExcel() {
        Console.WriteLine("Exporting ring data to excel..");
    }
    public void ExportingToPDF() {
        Console.WriteLine("Exporting ring data to pdf..");
    }

    public void ExportingToNotepad() {
        //create object of FileInfo for specified path
        FileInfo f1 = new FileInfo(@"D:\Bootcamp10\Projects\Day3\OutputRing.txt");
        //open file for read write
        FileStream fsToWrite = f1.Open(FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        StreamWriter sw = new StreamWriter(fsToWrite);
        Dictionary<int, string> ringRecord = new Dictionary<int, string> ();
        ringRecord.Add(1,"Ring 1");
        ringRecord.Add(2,"Ring 2");
        foreach(KeyValuePair<int,string> kvp in ringRecord) {
            sw.WriteLine("The ring id {0} stands for {1}", kvp.Key, kvp.Value);
        }
        sw.Close();
        fsToWrite.Close();
    }
}