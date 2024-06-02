using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        //create new object of stringbuilder
        StringBuilder sb = new StringBuilder();
        for(int i=0; i<10; i++)
        {
            //append the string
            sb.Append("Data"+i);
        }
        string result = sb.ToString();
        Console.WriteLine(result);
        /*
        jadinya bikin alamat baru. yang sebelumnya di-abandon
        result = "Monalisa";
        Console.WriteLine(result);       
        */ 
    }
}