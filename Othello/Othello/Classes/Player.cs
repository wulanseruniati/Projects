public class Player : IPlayer
{
    public Guid PlayerId  {get; private set;}
    public string PlayerName {get; private set;}

    public Player(string playerName)
    {
        PlayerId = Guid.NewGuid();
        PlayerName = playerName;
    }
}