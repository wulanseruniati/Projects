internal class Program
{
    private static void Main(string[] args)
    {   
        //creating object of necklace class using two parameters constructor (overloading)
        Necklace necklace1 = new Necklace(10,2.5,5);
        //calling the overriden method
        necklace1.Assembly();
        //calling the methods from the interfaces
        necklace1.CreateData();
        int[] locator = necklace1.GetLocator(necklace1.necklaceId);
        Console.WriteLine($"The necklace position is in shelf {locator[0]} row {locator[1]}");
        necklace1.ExportingToExcel();
        double totalWeight = necklace1.CalculateWeight(necklace1.chainWeight, necklace1.chainQty);
        Console.WriteLine("The jewellery weight is : " + totalWeight);
    
        //creating object of ring class using three parameters constructor (overloading)
        Ring ring1 = new Ring(1,2.5,3);
        //calling the overriden method
        ring1.Assembly();
        double weight = ring1.CalculateWeight(ring1.componentWeight, ring1.componentQty);
        Console.WriteLine("The jewellery weight is : " + weight);
        Dictionary<int,string> ringData = ring1.ShowData();
        foreach(KeyValuePair<int,string> kvp in ringData) {
            Console.WriteLine("The ring id {0} stands for {1}", kvp.Key, kvp.Value);
        }
        //calling the methods from the interfaces
        ring1.UpdateData(ring1.ringId);
        ring1.CheckRedundancyData<string,int>("trn_ring",ring1.ringId);
        //will generate error: ring1.ringId = 8;
        //calling the parent's method
        ring1.Polishing();
        ring1.ExportingToNotepad();
    }
}