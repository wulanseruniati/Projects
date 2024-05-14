internal class Program
{
    private static void Main(string[] args)
    {
        "Please input a positive whole number: ".Dump();
        //get user input
        var userInput = Console.ReadLine();
        //checking user input. only run the program if the input is int > 0. otherwise display error
        if (int.TryParse(userInput, out int inputN))
        {
            if (inputN < 0)
            {
                "Please input a whole number greater than zero".Dump();
            }
            else
            {
                //instantiate Foobar
                Foobar foobar = new(inputN);

                //print the queue using object from class PrintFoobar
                PrintFoobar printFoobar = new();
                if(foobar.queue != null)
                    printFoobar.InlinePrintQueue(foobar.queue);
            }
        }
        else
        {
            "Please input a valid positive whole number".Dump();
        }
    }
}