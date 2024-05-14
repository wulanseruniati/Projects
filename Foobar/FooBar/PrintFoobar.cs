public class PrintFoobar : IPrint<string> {
    public void InlinePrintQueue(Queue<string> collection) {        
        //action to print queue's value
        Action<string> InlinePrint = (tobePrinted) => tobePrinted.WriteDump();
        int urutan = 0;
        foreach(string number in collection)
        {
            if(urutan == collection.Count-1)
            {
                //end of queue, no need comma
                InlinePrint(number);
            }
            else {
                //needs comma to separate value
                InlinePrint(number + ",");
            }
            urutan++;
        }
    }
}