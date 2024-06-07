public interface IBudgetItemPrototype : ICloneable
{
    public Dictionary<string,decimal> Values { get;  }
    public string? Category { get;  }
    public string? Source { get;  }
    void AddToTotal(string date,decimal amount);
}