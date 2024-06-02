class GameController : IDisposable
{
    public List<int> totalPlayers;
    public List<object> allPlayers;
    public ExternalResource externalResources;

    private bool isDisposed = false;
    public void Dispose()
    {
        Dispose(true); //manggil si protected
        GC.SuppressFinalize(this);
    }
    protected void Dispose(bool disposing)
    {
        if (!isDisposed)
        {
            if (disposing)
            {
                //clean managed resource
            }
            //clean unmanaged resource
            isDisposed = true;
        }
    }
}

public class ExternalResource
{
    //
}
class Program
{
    static void Main()
    {
        //Car car = new();
        //car.Dispose();

    }
}