using System.Collections;
using System.Collections.Generic;
internal class Program
{
    private static void Main(string[] args)
    {
        //List - track score tiap player
        List<string> bp = new() { "Lisa", "Jennie", "Jisoo", "Rose" };
        //enumerator - pointer yg menelusuri collection
        IEnumerator<string> enumerator = bp.GetEnumerator();
        while (enumerator.MoveNext())
        {
            System.Console.WriteLine(enumerator.Current);
        }

        foreach (int number in GetNumbers())
        {
            System.Console.WriteLine(number);
        }

        //dictionary - key value . cth : phonebook
        Dictionary<string,int> ages = new Dictionary<string, int>();
        ages.Add("John",30);
        System.Console.WriteLine(ages["John"]);

        //arraylist - tidak type safety - todo list application
        ArrayList arrayList = new ArrayList();
        arrayList.Add(1);
        arrayList.Add("John");

        //LinkedList - konsep node : menambah & mengurangi dr kedua sisi (awal sm akhir)
        //history navigation
        LinkedList<int> linkedList = new LinkedList<int>();
        linkedList.AddLast(1);
        linkedList.AddFirst(2);

        //HashSet - tidak boleh sama : analisa text - unique words dr large document
        HashSet<int> set = new HashSet<int> {1,2,3};

        //stack - LIFO push dan pop - calculator reverse Polish notation
        Stack<int> stack = new Stack<int>();
        stack.Push(1);

        //Queue - FIFO - print spooler apps
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(1);
        queue.Enqueue(2);
        System.Console.WriteLine(queue.Dequeue());
    }

    //iterator
    public static IEnumerable<int> GetNumbers()
    {
        for (int i = 1; i < 10; i++)
        {
            yield return i;
        }
    }
}