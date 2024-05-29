using System.Text;

class Program
{
    static void Main()
    {
        using (FileStream fs = new FileStream("test1.txt", FileMode.Create, FileAccess.Write, FileShare.None)) 
        {
            string text = "Morning. I'm a bit hungry 😁";
            byte[] myBites = new byte[text.Length]; //buffer

            myBites = Encoding.UTF8.GetBytes(text);
            fs.Write(myBites,0,myBites.Length);
            Console.ReadLine();
        }

        using (FileStream fs1 = File.OpenRead("test1.txt")) {
            byte[] b = new byte[1024]; //buffer
            UTF8Encoding tmp = new(true);
            int readLen;
            while((readLen = fs1.Read(b,0,b.Length)) > 0)
            {
                System.Console.WriteLine(tmp.GetString(b,0,readLen));
            }
        }

        using (var sr = new StreamReader("test1.txt")) {
            System.Console.WriteLine(sr.ReadToEnd());
        }
    }
}