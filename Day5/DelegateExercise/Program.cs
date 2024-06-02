public static class Program
{
    public static void Main()
    {
        Player player = new();
        Score score = new();
        player.Scored += score.HandleScoreUpdate;
        player.OnScored();
    }
}