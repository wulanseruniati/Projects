public interface IPrint<T1,T2> where T1 : notnull {
    //interface for printing
    public void InlinePrintQueue(Queue<T1> collection, Dictionary<T1,T2> dictionary,T1 printMode, T1 numberInput);
}