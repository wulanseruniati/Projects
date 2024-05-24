using System.IO;
public class Player : IDisposable {
    private MemoryStream? managedResource;
    private FileStream? playerData;
    public bool dispose = false;

    public Player(string filePath)
    {
        playerData = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite);
    }

    public void Dispose() {
        Dispose(true);
    }
    public virtual void Dispose(bool disposing)
    {
        if (!dispose)
        {
            if (disposing)
            {
                //release managed resource
                managedResource = null;
                GC.SuppressFinalize(this);
            }
        }
        //release unmanaged resource
        playerData = null;
        dispose = true;
        System.Console.WriteLine("Disposing by dispose method");
    }

    ~Player() {
        Dispose(false);
        System.Console.WriteLine("Disposing by destructor/ finalizer");
    }
}