public class Program
{
    static void Main()
    {
        
        InstanceCreator();
        Console.ReadKey();
    }

    static void InstanceCreator() {
        Player player = new("D:\\Bootcamp10\\Projects\\PlayerData.txt");
        player.Dispose();
        System.Console.WriteLine(player.dispose);
    }
}