internal class Program
{
    private static void Main(string[] args)
    {
        //calling PlayerState data
        PlayerState spawn = PlayerState.Spawn;
        System.Console.WriteLine(spawn);//Spawn
        int spawnValue = (int)PlayerState.Spawn;
        System.Console.WriteLine(spawnValue);//0

        //calling GameState data
        GameState gameState = GameState.Started;
        System.Console.WriteLine(gameState);
        int gameStateValue = (int)GameState.Ended;
        System.Console.WriteLine(gameStateValue);
    }

    public enum PlayerState {
        Spawn, //default nol
        FullHealth,
        HalfHealth,
        Berserk,
        Dead
    }
    public enum GameState {
        Started = 100,
        Paused = 200,
        Ended = 300
    }
}