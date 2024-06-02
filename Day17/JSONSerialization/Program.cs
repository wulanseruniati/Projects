using System.Text.Json;

class Program
{
    static void Main()
    {
        Human yusa = new Human("Yusa", 26, "Tulungagung");
        Human ega = new Human("Ega", 22, "Semarang");
        Human rizqi = new Human("Rizqi", 24, "Bandung");
        Human fadl = new Human("Fadl", 23, "Jakarta");
        Human dewi = new Human("Dewi", 25, "Pati");
        Human wulan = new Human("Wulan", 29, "Bandung");
        Human bella = new Human("Bella", 24, "Kediri");
        Human jun = new Human("Jun", 23, "Balikpapan");
        //create new human:
        System.Console.WriteLine("Input name");
        string nama = Console.ReadLine();
        System.Console.WriteLine("Input age");
        int age = Int32.Parse(Console.ReadLine());
        System.Console.WriteLine("Input birth place");
        string? birthPlace = Console.ReadLine();
        Human newHuman = new(nama, age, birthPlace); 
        List<Human> bootcamp = new List<Human>() {
            yusa,
            ega,
            rizqi,
            fadl,
            dewi,
            wulan,
            bella,
            jun,
            newHuman
        };
        string json = JsonSerializer.Serialize(bootcamp);
        using (StreamWriter sw = new("file.json"))
        {
            sw.WriteLine(json);
        }

        //deserialization
        string result;
        using(StreamReader sr = new("file.json")) {
            result = sr.ReadToEnd();
        }
        List<Human> bootcampResult = JsonSerializer.Deserialize<List<Human>>(result);
        foreach(var human in bootcampResult)
        {
            System.Console.WriteLine($"Name : {human.Name}, age : {human.Age}, birth place : {human.BirthPlace}" );
        }
    }
}

class Human
{
    public string Name { get; private set; }
    public string BirthPlace { get; private set; }
    public int Age { get; private set; }
    public Human(string name, int age, string birthPlace)
    {
        Name = name;
        Age = age;
        BirthPlace = birthPlace;
    }
}