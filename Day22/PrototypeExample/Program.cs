using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        // Creating objects of Expense and Income
        IBudgetItemPrototype originalExpense = new Expense("Food","Food Stall");
        IBudgetItemPrototype originalIncome = new Income("Salary","Company");

        // Adding the expense and income
        originalExpense.AddToTotal(DateTime.UtcNow.ToString(),50.0m);
        originalIncome.AddToTotal(DateTime.UtcNow.ToString(),3000.0m);

        // Cloning objects
        var clonedExpense = (IBudgetItemPrototype)originalExpense.Clone();
        var clonedIncome = (IBudgetItemPrototype)originalIncome.Clone();

        // Displaying original and cloned objects
        Console.WriteLine("Original Expense:");
        Printer.PrintInfo(originalExpense);
        Console.WriteLine("\nCloned Expense:");
        Printer.PrintInfo(clonedExpense);

        Console.WriteLine("\nOriginal Income:");
        Printer.PrintInfo(originalIncome);
        Console.WriteLine("\nCloned Income:");
        Printer.PrintInfo(clonedIncome);

        System.Console.WriteLine("\n================Modifying the cloned objects==================\n");
        
        // updating the cloned expense and income
        clonedExpense.AddToTotal(DateTime.Now.ToString(),150.0m);
        clonedIncome.AddToTotal(DateTime.Now.ToString(),5000.0m);

        // Displaying original and cloned objects
        Console.WriteLine("Original Expense:");
        Printer.PrintInfo(originalExpense);
        Console.WriteLine("\nCloned Expense:");
        Printer.PrintInfo(clonedExpense);

        Console.WriteLine("\nOriginal Income:");
        Printer.PrintInfo(originalIncome);
        Console.WriteLine("\nCloned Income:");
        Printer.PrintInfo(clonedIncome);

        Console.ReadLine();
    }
}
