class Program
{
    static async Task Main() {
        //synchronous first
        Player player = AddPlayer();
        
        FileManager fileManager = new();
        //async
        await Asynchronous(player,fileManager);
        //synchronous again
        player.OutputPlayer();
        //showing output log
        Task<string> outputLog = Task.Run(() => fileManager.Read("../logPlayer.txt"));
        System.Console.WriteLine(outputLog.Result);
        //demo
        Task<int> task = new Task<int>(ReturnNine);
        task.Start();
        System.Console.WriteLine(task.Result);
        var task2 = new Task<Dictionary<string,int>>(ReturnDictionary);
        task2.Start();
        foreach(var data in task2.Result )
        {
            System.Console.WriteLine($"Penduduk: {data.Key} berumur {data.Value}");
        }
    }
    static int ReturnNine() {
        return 9;
    }
    static Dictionary<string,int> ReturnDictionary() {
        Dictionary<string,int> dictionary = new();
        dictionary.Add("Yono",27);
        return dictionary;
    }

    static Player AddPlayer() {
        return new Player("Wulan");
    }

    static async Task Asynchronous(Player player, FileManager fileManager) {
        Task write = Task.Run(() =>fileManager.Write("../logPlayer.txt","The player "+player.PlayerName+" joined"));
        Task write2 = Task.Run(() =>fileManager.Write("../logGame.txt","The game started"));
        
        await Task.WhenAll(write,write2);
    }
}