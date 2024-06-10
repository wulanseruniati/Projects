public class Printer {
    //doesn't instantiate concrete implementations directly but :
    //operates on the `IBudgetItemPrototype` interface
    //abstracts the creation process and allows for decoupling between the client code 
    //and the specific implementations of budget items
    public static void PrintInfo(IBudgetItemPrototype budget) {
        Console.WriteLine($"Category: {budget.Category}, Id : {budget.BudgetId}, Source: {budget.Source}, Date acquired & Total:");
        foreach (var income in budget.Values)
        {
            Console.WriteLine(income);
        }
    }
    //tanpa abstract factory :
    public static void PrintInfoExpense(Expense budget) {
        Console.WriteLine($"Category: {budget.Category}, Id : {budget.BudgetId}, Source: {budget.Source}, Date acquired & Total:");
        foreach (var income in budget.Values)
        {
            Console.WriteLine(income);
        }
    }
    public static void PrintInfoIncome(Income budget) {
        Console.WriteLine($"Category: {budget.Category}, Id : {budget.BudgetId}, Source: {budget.Source}, Date acquired & Total:");
        foreach (var income in budget.Values)
        {
            Console.WriteLine(income);
        }
    }
}