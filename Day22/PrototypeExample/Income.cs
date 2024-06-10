using System.Diagnostics;

public class Income : IBudgetItemPrototype
{
    public Dictionary<string, decimal> Values { get; private set; }
    public string? Source { get; private set; }
    public string? Category { get; private set; }
    public Guid BudgetId { get; private set; }

    public Income() 
    { 
        BudgetId = Guid.NewGuid();
        Values = new Dictionary<string, decimal>(); 
    }
    //overload constructor
    public Income(string category, string source)
    {
        Values = new Dictionary<string, decimal>();
        Source = source;
        Category = category;
        BudgetId = Guid.NewGuid();
    }

    // Copy/ clone constructor
    public Income(Income source)
    {
        Values = new Dictionary<string, decimal>(source.Values);
        Source = source.Source;
        Category = source.Category;
        BudgetId = Guid.NewGuid();
    }

    public void AddToTotal(string date, decimal amount) => Values.Add(date, amount);

    public object Clone() => new Income(this);
}