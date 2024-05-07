using SemiComponent;

namespace FinishedGoods {
    public class Bracelet {
        public string? braceletType;
        public int standardWeight;
        public Chain chain;

        public Bracelet(string braceletType, int standardWeight, Chain chain)
        {
            this.braceletType = braceletType;
            this.standardWeight = standardWeight;
            this.chain = chain;
        }

        public void printInformation(string braceletType)
        {
            Console.WriteLine($"The bracelet type is : {braceletType}.");
        }

        public void printInformation(string braceletType, int standardWeight)
        {
            Console.WriteLine($"The bracelet type is : {braceletType} and the standard weight is {standardWeight} gram");
        }
    }
}