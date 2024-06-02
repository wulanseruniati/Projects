using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

class Program {
    static void Main() {
        Player juan = new("Juan",2000,300,1500);
        Player reno = new("Reno",4000,400,4500);
        Player didi = new("Didi",5000,500,8500);

        List<Player> players = new List<Player>() {
            juan,reno,didi
        };
        
        DataContractJsonSerializer serializer = new(typeof(List<Player>));
        using (FileStream fs = new("players.json",FileMode.Create))
        {
            serializer.WriteObject(fs,players);
        }
    }
}

[DataContract]
class Player {
    [DataMember]
    private string _name;
    [DataMember]
    private int _money;
    [DataMember]
    public int Gold {get; set;}
    [DataMember]
    public int Exp {get; set;}
    public Player(string name, int money, int gold, int exp) {
        _name = name;
        _money = money;
        Gold = gold;
        Exp = exp;
    }
    public string GetName() {
        return _name;
    }
    public int GetMoney() {
        return _money;
    }
}