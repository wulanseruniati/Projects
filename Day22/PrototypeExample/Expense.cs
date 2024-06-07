public class Expense : IBudgetItemPrototype
{
    public Dictionary<string,decimal> Values { get; private set; }
    public string? Source { get; private set; }
    public string? Category { get; private set; }

    public Expense() => Values = new Dictionary<string,decimal>(); 
    //overload
    public Expense(string category, string source) {
        Values = new Dictionary<string,decimal>(); 
        Source = source;
        Category = category;
    }

    // Copy constructor
    public Expense(Expense source)
    {
        Values = new Dictionary<string,decimal>(source.Values);
        Source = source.Source;
        Category = source.Category;
    }

    public void AddToTotal(string date,decimal amount) => Values.Add(date,amount); 

    public object Clone() => new Expense(this); 
}