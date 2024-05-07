namespace vehicle;

public class Engine {
    public string engineType;
    public int engineHP;

    public string engineBrand;

    public Engine(string engineType, int engineHP, string engineBrand) {
        this.engineType = engineType;
        this.engineHP = engineHP;
        this.engineBrand = engineBrand;
    }

    public void PrintAttribute(string engineType, int engineHP, string engineBrand) {
        Console.WriteLine($"The engine type is {engineType}");
        Console.WriteLine($"The engine horse power is {engineHP}");
        Console.WriteLine($"The engine brand is {engineBrand}");
    }
}