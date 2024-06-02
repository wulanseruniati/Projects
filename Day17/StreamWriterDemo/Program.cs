class Program {
    static void Main() {
        Write("test1.txt","Morning. I'm a bit hungry 😁");
    }

    static void Write(string path, string message) {
        using(StreamWriter stream = new(path))
        {
            stream.WriteLine(message);
        }
    }
}