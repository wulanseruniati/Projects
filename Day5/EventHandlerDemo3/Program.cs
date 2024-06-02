public static class Program
{
    // In the main program, create an instance of the Button class and subscribe to the Clicked event.
    public static void Main()
    {
        Door door = new();
        SecuritySystem security = new();
        door.Opened += security.OnDoorOpened;
        door.Open();
    }
}