class Program {
    static void Main() {
        using(FileStream fs = new("file.txt", FileMode.Create, FileAccess.Write))
        {
            string[] input = {"I'm a human","Living in a world","The impermanence world"};
            using(StreamWriter outputFile = new StreamWriter(fs))
            {
                foreach (var word in input)
                {
                    outputFile.WriteLine(word);
                }
            }
        }

        using(FileStream fs = new("file.txt", FileMode.Append, FileAccess.Write))
        {
            using(StreamWriter outputFile = new StreamWriter(fs))
            {
                outputFile.WriteLine("I love eating meatballs");
            }
        }

        using(StreamReader inputFile = new StreamReader("file.txt"))
        {
            System.Console.WriteLine(inputFile.ReadLine());
            System.Console.WriteLine(inputFile.ReadLine());
            System.Console.WriteLine(inputFile.ReadLine());
            System.Console.WriteLine(inputFile.ReadLine());
        }
    }
}