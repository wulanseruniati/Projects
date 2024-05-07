public class Horse : Animal {
    public Horse(int age, string gender, bool isAlive) : base (age, gender, isAlive) 
    {
        //
    }

    public void SpeedRun()
    {
        Console.WriteLine("Ruun");
    }
}