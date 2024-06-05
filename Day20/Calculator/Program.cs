using System.IO.Compression;
namespace CalculatorLib;
class Program
{
    static void Main()
    {
        //CalculatorSimple.ReverseWords("Budi");
    }
}
public class CalculatorSimple
{
    public int Add(int number1, int number2)
    {
        return number1 + number2;
        //System.Console.WriteLine("Result of add method is : "+ number1+number2);
    }

    public int SubstractNumber(int number1, int number2)
    {
        return number1 - number2;
    }

    public string ReverseMethod(int number1)
    {
        return number1.ToString();
    }

    public string ReverseWords(string words)
    {
        if (words == String.Empty)
        {
            return String.Empty;
        }
        else if (words is null)
        {
            return null;
        }
        else
        {
            char[] stringArray = words.ToCharArray();
            Array.Reverse(stringArray);
            string reversedStr = new string(stringArray);
            return reversedStr;
        }
    }
}

public class Person {
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public string GetFullName(Person person) {
        if(person == null) return null;
        return $"{person.FirstName} {person.LastName}";
    }
}