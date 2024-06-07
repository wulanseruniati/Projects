using System.Diagnostics;

public class Income : IBudgetItemPrototype
{
    public Dictionary<string,decimal> Values { get; private set; }
    public string? Source { get; private set; }
    public string? Category { get; private set; }

    public Income() => Values = new Dictionary<string,decimal>();
    //overload constructor
    public Income(string category, string source) {
        Values = new Dictionary<string,decimal>();
        Source = source;
        Category = category;
    }

    // Copy constructor
    public Income(Income source)
    {
        Values = new Dictionary<string,decimal>(source.Values);
        Source = source.Source;
        Category = source.Category;
    }

    public void AddToTotal(string date,decimal amount) => Values.Add(date,amount); 

    public object Clone() => new Income(this); 
}