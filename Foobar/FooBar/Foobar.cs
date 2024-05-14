public class Foobar
{
    public int CountNumber { get; private set; } //the number from user's input
    public Queue<string>? QueueStored { get; private set; } //the queue to be printed

    public Foobar(int countNumber)
    {
        //constructor to set CountNumber and populate queue
        CountNumber = countNumber;
        PopulateQueue();
    }

    public void PopulateQueue() {        
        QueueStored = new Queue<string>();
        //lambda expression to populate queue
        void AddToQueue(string number) => QueueStored.Enqueue(number);
        for (int i = 0; i <= CountNumber; i++)
        {
            //populate queue with "foobar" if the number is the multiplication of 3 & 5
            if (i % 5 == 0 && i % 3 == 0 && i > 0)
            {
                AddToQueue("foobar");
            }
            //populate queue with "foo" if the number is the multiplication of 3
            else if (i % 3 == 0 && i > 0)
            {
                AddToQueue("foo");
            }
            //populate queue with "bar" if the number is the multiplication of 5
            else if (i % 5 == 0 && i > 0)
            {
                AddToQueue("bar");
            }
            //populate queue with the number if the number is neither the multiplication of 3 nor 5
            else
            {
                AddToQueue(i.ToString());
            }
        }
    }
}