public class Car : IDisposable {
    private bool isDisposed = false;
    public Car() {
        System.Console.WriteLine("Creator");
    }
    ~Car() {
        System.Console.WriteLine("Destructor");
        Dispose(false);
    }
    public void Dispose() {
        Dispose(true); //manggil si protected
        GC.SuppressFinalize(this);
    }
    protected void Dispose(bool disposing) {
        if(!isDisposed)
        {
            if(disposing)
            {
                //clean managed resource
            }
            //clean unmanaged resource
            isDisposed = true;
        }        
    }
}