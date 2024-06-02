internal class Program
{
    private static void Main(string[] args)
    {
        int[] numbers = {1,2};
        Student std = new();
        //return only selected names of children
        std.FilterStudentNames(numbers);
    }
}