public class Printer {
    //doesn't instantiate concrete implementations directly but operates on the `IBudgetItemPrototype` interface
    //abstracts the creation process and allows for decoupling between the client code and the specific implementations of budget items
    public static void PrintInfo(IBudgetItemPrototype budget) {
        Console.WriteLine($"Category: {budget.Category}, Source: {budget.Source}, Date acquired & Total:");
        foreach (var income in budget.Values)
        {
            Console.WriteLine(income);
        }
    }
}