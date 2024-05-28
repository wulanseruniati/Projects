class Program
{
    static async Task Main() {
        //synchronous first
        Player player = AddPlayer();
        //async
        await Asynchronous(player);
        //synchronous again
        player.OutputPlayer();
    }

    static Player AddPlayer() {
        return new Player("Wulan");
    }

    static async Task Asynchronous(Player player) {
        FileManager fileManager = new();
        Task write = Task.Run(() =>fileManager.Write("../logPlayer.txt","The player "+player.PlayerName+" joined"));
        Task write2 = Task.Run(() =>fileManager.Write("../logGame.txt","The game started"));
        
        await Task.WhenAll(write,write2);
    }
}