public class Foobar
{
    public int CountNumber { get; private set; } //the number from user's input
    public Queue<int>? QueueStored { get; private set; } //the queue to be printed
    public Dictionary<int,string>? NumberDictionary { get; private set; } //the dictionary of special character

    public Foobar(int countNumber)
    {
        //constructor to set CountNumber and populate queue
        CountNumber = countNumber;
        PopulateQueue();
        //initialize the dictionary
        NumberDictionary = new Dictionary<int, string>
        {
            { 3, "foo" },
            { 5, "bar" }
        };
    }

    public void PopulateQueue() {        
        QueueStored = new Queue<int>();
        //lambda expression to populate queue
        void AddToQueue(int number) => QueueStored.Enqueue(number);
        for (int i = 0; i <= CountNumber; i++)
        {
            //populate queue with the number if the number is neither the multiplication of 3 nor 5
            AddToQueue(i);
        }
    }
}