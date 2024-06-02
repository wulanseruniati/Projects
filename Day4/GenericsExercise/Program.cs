internal class Program
{
    private static void Main(string[] args)
    {
        //instantiate new object student
        Student<string, int, double> student = new Student<string, int, double>
        {
            stdName = "Student1",
            stdPhoneNum = "022",
            stdAge = 12,
            stdHeight = 120.0
        };
        //calling generic method
        student.ShowInformation<double>(40.0);
    }
}