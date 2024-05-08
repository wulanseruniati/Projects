internal class Program
{
    private static void Main(string[] args)
    {   
        //creating object of necklace class using two parameters constructor (overloading)
        Necklace necklace1 = new Necklace(10,2.5);
        //calling the overriden method
        necklace1.Assembly();
        necklace1.CreateData();
        double totalWeight = necklace1.CalculateWeight(necklace1.chainWeight, necklace1.chainQty);
        Console.WriteLine("The jewellery weight is : " + totalWeight);
    
        //creating object of ring class using three parameters constructor (overloading)
        Ring ring1 = new Ring(1,2.5,3);
        //calling the overriden method
        ring1.Assembly();
        double weight = ring1.CalculateWeight(ring1.componentWeight, ring1.componentQty);
        Console.WriteLine("The jewellery weight is : " + weight);
        ring1.UpdateData(ring1.ringId);
        //will generate error: ring1.ringId = 8;
        //calling the parent's method
        ring1.Polishing();        
    }
}