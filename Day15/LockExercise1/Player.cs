public class Player {
    //
    public Guid PlayerId {get; private set;}
    public string PlayerName {get; private set;}

    public Player(string playerName) {
        PlayerId = new Guid();
        PlayerName = playerName;
    }

    public void OutputPlayer() {
        System.Console.WriteLine("Fetching data..");
        Thread.Sleep(TimeSpan.FromMilliseconds(0.1));
        System.Console.WriteLine("The player id is : " + PlayerId);
    }
}