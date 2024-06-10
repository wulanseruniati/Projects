public class VendorALight
{
    public void turnOn() {
        System.Console.WriteLine("Turn on A");
    }
    public void turnoff() {
        System.Console.WriteLine("Turn off A");
    }
}

public class VendorBLight
{
    public void turnLight(bool on) {
        if(on)
        {
            System.Console.WriteLine("Turn on B");
        }
        else {
            System.Console.WriteLine("Turn off B");
        }
    }
}

// Common interface for lights
public interface ILight
{
    void TurnOn();
    void TurnOff();
}

// Adapter for VendorALight
public class VendorALightAdapter : ILight
{
    private VendorALight vendorALight;

    public VendorALightAdapter(VendorALight light)
    {
        this.vendorALight = light;
    }

    public void TurnOn()
    {
        vendorALight.turnOn();
    }

    public void TurnOff()
    {
        vendorALight.turnoff();
    }
}

// Adapter for VendorBLight
public class VendorBLightAdapter : ILight
{
    private VendorBLight vendorBLight;

    public VendorBLightAdapter(VendorBLight light)
    {
        this.vendorBLight = light;
    }

    public void TurnOn()
    {
        vendorBLight.turnLight(true);
    }

    public void TurnOff()
    {
        vendorBLight.turnLight(false);
    }
}

// Client program
class Program
{
    static void Main(string[] args)
    {
        // Create instances of VendorALight and VendorBLight
        VendorALight vendorALight = new VendorALight();
        VendorBLight vendorBLight = new VendorBLight();

        // Create adapters
        ILight adapterA = new VendorALightAdapter(vendorALight);
        ILight adapterB = new VendorBLightAdapter(vendorBLight);

        // Use adapters
        adapterA.TurnOn(); // This will call VendorALight's turnOn method
        adapterA.TurnOff(); // This will call VendorALight's turnoff method

        adapterB.TurnOn(); // This will call VendorBLight's turnLight method with parameter true
        adapterB.TurnOff(); // This will call VendorBLight's turnLight method with parameter false
    }
}
