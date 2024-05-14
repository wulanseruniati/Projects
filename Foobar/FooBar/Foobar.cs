public class Foobar
{
    public int CountNumber { get; private set; }

    //create queue
    public Queue<string> queue = new Queue<string>();

    public Foobar(int countNumber)
    {
        CountNumber = countNumber;
        Action<string> populateQueue = (number) => queue.Enqueue(number);
        for (int i = 0; i <= CountNumber; i++)
        {
            //populate queue
            if (i % 5 == 0 && i % 3 == 0 && i > 0)
            {
                populateQueue("foobar");
            }
            else if (i % 3 == 0 && i > 0)
            {
                populateQueue("foo");
            }
            else if (i % 5 == 0 && i > 0)
            {
                populateQueue("bar");
            }
            else
            {
                populateQueue(i.ToString());
            }
        }
    }
}