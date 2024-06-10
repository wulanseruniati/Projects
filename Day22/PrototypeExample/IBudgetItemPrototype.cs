public interface IBudgetItemPrototype : ICloneable
{
    public Dictionary<string,decimal> Values { get; }
    public string? Category { get; }
    public string? Source { get; }
    public Guid BudgetId { get; }
    void AddToTotal(string date,decimal amount);
}