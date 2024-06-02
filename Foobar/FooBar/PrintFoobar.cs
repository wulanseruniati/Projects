public class PrintFoobar : IPrint<int, string>
{
    Action<string> InlinePrint = (tobePrinted) => tobePrinted.WriteDump();
    public void InlinePrintQueue(Queue<int> collection, Dictionary<int, string> dictionary, int printMode, int numberInput)
    {
        //printmode
        if (printMode == 1)
        {
            InlinePrint(numberInput.ToString());
        }
        else
        {
            //action to print queue's value
            int urutan = 0;
            //temporary variable
            bool isExist = false;
            foreach (int number in collection)
            {
                if (number > 0)
                {
                    //looping to check dictionary modulus
                    foreach (KeyValuePair<int, string> dictNumber in dictionary)
                    {
                        if (number % dictNumber.Key == 0)
                        {
                            //print the dictionary value
                            InlinePrint(dictNumber.Value);
                            isExist = true;
                        }
                    }
                    if (isExist)
                    {
                        //no need to print
                        isExist = false;
                    }
                    else
                    {
                        //print the number
                        InlinePrint(number.ToString());
                    }
                }
                else
                {
                    //print the number zero
                    InlinePrint(number.ToString());
                }
                if (urutan < collection.Count-1)
                {
                    //comma as separator if not the last value
                    InlinePrint(",");
                }
                urutan++;
            }
        }
    }
}