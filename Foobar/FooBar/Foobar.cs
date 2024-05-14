public class Foobar
{
    public int CountNumber { get; private set; } //the number from user's input
    public Queue<string> queue { get; private set; } //the queue to be printed

    public Foobar(int countNumber)
    {
        CountNumber = countNumber;
        queue = new Queue<string>();
        //action to populate queue
        Action<string> populateQueue = (number) => queue.Enqueue(number);
        for (int i = 0; i <= CountNumber; i++)
        {
            //populate queue with "foobar" if the number is the multiplication of 3 & 5
            if (i % 5 == 0 && i % 3 == 0 && i > 0)
            {
                populateQueue("foobar");
            }
            //populate queue with "foo" if the number is the multiplication of 3
            else if (i % 3 == 0 && i > 0)
            {
                populateQueue("foo");
            }
            //populate queue with "bar" if the number is the multiplication of 5
            else if (i % 5 == 0 && i > 0)
            {
                populateQueue("bar");
            }
            //populate queue with the number if the number is neither the multiplication of 3 nor 5
            else
            {
                populateQueue(i.ToString());
            }
        }
    }
}