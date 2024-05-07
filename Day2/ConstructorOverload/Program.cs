using SemiComponent;
using FinishedGoods;

internal class Program
{
    private static void Main(string[] args)
    {
        //create new object of Chain
        Chain chain1 = new Chain("Standard Weight");
        //overload constructor Chain two parameter
        Chain chain2 = new Chain("Light Weight", 0.25f);
        float totalWeight = chain2.calculateWeight(10);
        Console.WriteLine("The total weight of the chain is " + totalWeight);

        //create new object of Bracelet        
        Bracelet bracelet1 = new Bracelet("Plain Bracelet", 25, chain1);
        //printInformation with one parameter
        if (bracelet1.braceletType == null)
        { throw new NullReferenceException("The bracelet type is null"); }
        else
        {
            bracelet1.printInformation(bracelet1.braceletType);
        }

        //create new object of bracelet
        Bracelet bracelet2 = new Bracelet("Bracelet with Head", 25, chain2);
        //overload printInformation with two parameter
        if (bracelet2.braceletType == null)
        { throw new NullReferenceException("The bracelet type is null"); }
        else
        {
            bracelet2.printInformation(bracelet2.braceletType, bracelet2.standardWeight);
        }
    }
}