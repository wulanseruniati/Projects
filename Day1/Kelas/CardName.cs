public class CardName : Card {
    public string? Nma {
        get {
        if(Nma != null) {
            return Nma;
        }
        else 
        {
            return null;
        }
    } private set {
        this.Nma = value;
    }}
}