internal class Program
{
    private static void Main(string[] args)
    {
        //get user input for choosing print mode
        "Please choose print mode:".Dump();
        "0 for printing all the numbers from 0.".Dump();
        "1 for printing the input number only.".Dump();
        "(0/1)? ".Dump();
        //get user input
        var inputMode = Console.ReadLine();
        //checking user input. only run the program if the input is in 0 or 1
        if (int.TryParse(inputMode, out int chosenMode))
        {
            if (chosenMode == 0 || chosenMode == 1)
            {
                "Please input a positive whole number: ".Dump();
                //get user input
                var userInput = Console.ReadLine();
                //checking user input. only run the program if the input is int > 0. otherwise display error
                if (int.TryParse(userInput, out int inputNumber))
                {
                    if (inputNumber <= 0)
                    {
                        "Please input a whole number greater than zero".Dump();
                    }
                    else
                    {
                        //instantiate Foobar
                        Foobar foobar = new(inputNumber);

                        //print the queue using object from class PrintFoobar
                        PrintFoobar printFoobar = new();
                        if (foobar.QueueStored != null && foobar.NumberDictionary != null)
                            printFoobar.InlinePrintQueue(foobar.QueueStored, foobar.NumberDictionary,chosenMode,inputNumber);
                    }
                }
                else
                {
                    "Please input a valid positive whole number".Dump();
                }
            }
            else
            {
                "The valid input is only 0 or 1.".Dump();
            }
        }
        else
        {
            "The valid input is only 0 or 1.".Dump();
        }
    }
}