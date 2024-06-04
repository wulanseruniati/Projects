internal class Program
{
    private static void Main(string[] args)
    {   
        //OSP
        Necklace necklace1 = new Necklace(10,2.5,5);
        //calling the methods from the interfaces
        necklace1.CreateData();
        necklace1.UpdateData(necklace1.necklaceId);
        Dictionary<int,string> necklaceData = necklace1.FetchData();
        foreach (var data in necklaceData)
        {
            System.Console.WriteLine($"Id {data.Key} is {data.Value}");
        }
    }
}