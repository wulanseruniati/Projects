class Program
{
    static async Task Main()
    {

        //synchronous first
        Player player = AddPlayer();

        FileManager fileManager = new();
        //async
        await Asynchronous(player, fileManager);
        //synchronous again
        player.OutputPlayer();        
        try
        {
            //trying to show output log, but triggering some exception
            Task<string> outputLog = Task.Run(() => fileManager.Read("../logPlayerr.txt"));
            System.Console.WriteLine(outputLog.Result);
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
        //demo
        try
        {
            Task task = Task.Run(() => ExceptionMaker());
            task.Wait();
        }
        catch (Exception e)
        {
            System.Console.WriteLine(e.Message);
        }
    }
    static void ExceptionMaker()
    {
        throw new FormatException("Exception thrown from Exception Maker");
    }

    static Player AddPlayer()
    {
        return new Player("Wulan");
    }

    static async Task Asynchronous(Player player, FileManager fileManager)
    {
        Task write = Task.Run(() => fileManager.Write("../logPlayer.txt", "The player " + player.PlayerName + " joined"));
        Task write2 = Task.Run(() => fileManager.Write("../logGame.txt", "The game started"));

        await Task.WhenAll(write, write2);
    }
}