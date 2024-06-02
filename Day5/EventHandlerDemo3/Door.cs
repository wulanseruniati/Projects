public class Door {
    public event EventHandler? Opened;

    public void Open() {
        System.Console.WriteLine("Door is opened");
        Opened?.Invoke(this, EventArgs.Empty);
    }
}