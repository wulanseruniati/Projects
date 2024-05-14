public class Wallet : IComparable<Wallet> { 
    public int Money {get; set;}
    public int CompareTo(Wallet other) {
        int? j = int.Parse(other);
        return j; 
    }
}