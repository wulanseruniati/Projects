using System.Runtime.Serialization;
using System.Xml.Serialization;

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
        List<Human> bootcamp = new List<Human>() {
            yusa,
            ega,
            rizqi,
            fadl,
            dewi,
            wulan,
            bella,
            jun
        };

        XmlSerializer xmlSerializer = new(typeof(List<Human>));
        using (StreamWriter sw = new("file.xml"))
        {
            xmlSerializer.Serialize(sw, bootcamp);
        }
        //deserialization
        List<Human> bootcampOutput;
        using(StreamReader sr = new("file.xml")) {
            bootcampOutput = (List<Human>)xmlSerializer.Deserialize(sr);
        }
        foreach(var human in bootcampOutput)
        {
            System.Console.WriteLine($"Name : {human.Name}, age : {human.Age}, birth place : {human.BirthPlace}" );
        }

        //menyela dengan if-else
        System.Console.WriteLine(CalculationReturn(15,5));

    }

    static int CalculationReturn(int a, int b) {
        if(a <= 0)
        {
            return a+b;
        }
        return a-b;
    }
}

public class Human
{
    public string Name { get; set; }
    public string BirthPlace { get; set; }
    public int Age { get; set; }

    public Human() {
        //
    }
    public Human(string name, int age, string birthPlace)
    {
        Name = name;
        Age = age;
        BirthPlace = birthPlace;
    }
}