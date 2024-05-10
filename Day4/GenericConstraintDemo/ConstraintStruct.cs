public class ConstraintStruct<T> where T : struct
{
    public T? Message;
    public void GenericMethod(T Param1, T Param2)
    {
        Console.WriteLine($"Message: {Message}");
        Console.WriteLine($"Param1: {Param1}");
        Console.WriteLine($"Param2: {Param2}");
    }
}