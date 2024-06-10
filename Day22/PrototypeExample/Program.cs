using System;
using System.Collections.Generic;
class Program
{
    static void Main(string[] args)
    {
        /*
        Factory saja - menunda instantiation
        IBudgetItemPrototype originalExpense;

        string objectToBeCreated = Console.ReadLine();
        //factory design pattern
        if (objectToBeCreated == "Income")
        {
            originalExpense = new Income();
            originalExpense.AddToTotal(DateTime.UtcNow.ToString(), 3000.0m);
            Console.WriteLine("Original Income:");
            Printer.PrintInfo(originalExpense);

        }
        else if (objectToBeCreated == "Expense")
        {
            originalExpense = new Expense();
            originalExpense.AddToTotal(DateTime.UtcNow.ToString(), 50.0m);
            Console.WriteLine("Original Expense:");
            Printer.PrintInfo(originalExpense);
        }
        else
        {
            System.Console.WriteLine("Please choose expense or income");
        }
        */

        //Creating objects of Expense and Income - the type is interface to implement abstract factory
        IBudgetItemPrototype originalExpense = new Expense("Food","Food Stall");
        IBudgetItemPrototype originalIncome = new Income("Salary","Company");

        // Adding the expense and income
        originalExpense.AddToTotal(DateTime.UtcNow.ToString(),50.0m);
        originalIncome.AddToTotal(DateTime.UtcNow.ToString(),3000.0m);

        // Cloning objects - no need to know the concrete class
        var clonedExpense = (IBudgetItemPrototype)originalExpense.Clone();
        var clonedIncome = (IBudgetItemPrototype)originalIncome.Clone();
        //clone kedua
        var clonedExpense2 = (IBudgetItemPrototype)originalExpense.Clone();
        var clonedIncome2 = (IBudgetItemPrototype)originalIncome.Clone();

        // Displaying original and cloned objects using method that implements abstract factory
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
