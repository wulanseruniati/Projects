using System.IO;

class ResourceHandler
{
    private MemoryStream managedResource;
    private FileStream unmanagedResource;
    public bool dispose = false;
    Pineapple spongeBob = new Pineapple();

    //intellisense

    public ResourceHandler(string filePath)
    {
        unmanagedResource = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    public virtual void Dispose(bool disposing)
    {
        if (!dispose)
        {
            if (disposing)
            {
                //release managed resource
                spongeBob = null;
                GC.SuppressFinalize(this);
            }
        }
        //release unmanaged resource
        unmanagedResource.Dispose();
        unmanagedResource = null;
        dispose = true;
    }

    ~ResourceHandler() {
        Dispose(false);
        System.Console.WriteLine(dispose);
    }
}

public class Pineapple
{

}

public class Program
{
    static void Main()
    {
        ResourceHandler resourceHandler = new("D:\\Bootcamp10\\Projects\\Cat.txt");
        resourceHandler.Dispose(true);
        System.Console.WriteLine(resourceHandler.dispose);
    }
}