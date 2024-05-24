public class Program
{
    static void Main()
    {
        string fileName = "../text.txt";
        FileManager fileManager = new();
        fileManager.Write(fileName,"Ingin liburan");
        System.Console.WriteLine(fileManager.Read(fileName));
    }
}

class FileManager {
    public void Write(string path, string message) {
        using(StreamWriter stream = new(path))
        {
            stream.WriteLine(message);
        }
    }
    public string Read(string path) {
        string? result;
        using(StreamReader stream = new(path))
        {
            result = stream.ReadLine();
        }
        return result;
    }
}