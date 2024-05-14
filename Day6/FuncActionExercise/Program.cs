
    public delegate int ReturnStock(int id);
    internal class Program
{
    private static void Main(string[] args)
    {
        InventoryItem inventoryItem = new(1);
        //delegate
        ReturnStock returnStock = new ReturnStock(inventoryItem.returnStockUpdate);
        System.Console.WriteLine("(Delegate) The latest stok of item " + inventoryItem.ItemId + " is " + returnStock.Invoke(10));
        //func normal
        Func<int,int> returnUpdatedStock = inventoryItem.returnStockUpdate;
        System.Console.WriteLine("(Func) The latest stok of item " + inventoryItem.ItemId + " is " + returnUpdatedStock.Invoke(-5));
        //Action normal
        Action<int> printInfo = inventoryItem.printInformation;
        printInfo.Invoke(1);        
        //func with lambda
        Func<int> getRandomNumber = () => new Random().Next(1,100);
        System.Console.WriteLine("(Func Lambda) Random number is : " + getRandomNumber.Invoke());
        //action with lambda
        Action<string> printAction = (i) => System.Console.WriteLine(i);
        printAction.Invoke("This is action with lambda");
    }
}