internal class Program
{
    private static void Main(string[] args)
    {
        //calling Gender data
        Gender gender = Gender.Unknown;
        System.Console.WriteLine(gender);//unknown
        int genderValue = (int)Gender.Unknown;
        System.Console.WriteLine(genderValue);//0
    }

    public enum Gender {
        Unknown, //default nol
        Male,
        Female
    }
}