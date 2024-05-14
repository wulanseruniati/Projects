internal class Program
{
    private static void Main(string[] args)
    {
        System.Console.WriteLine("Please input a number: ");
        //get user input
        int.TryParse(Console.ReadLine(),out int inputN);
        //instantiate Foobar
        Foobar foobar = new(inputN);
        //create an action to populate queue        

        //print the queue
        foreach(string urutan in foobar.queue)
        {
            System.Console.Write(urutan + ",");
        }
    }
}