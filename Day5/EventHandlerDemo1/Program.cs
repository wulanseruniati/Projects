using System;

// Declare a delegate type with the signature for the event handler method.
//kalau gamau declare delegate, pakai event nya EventHandler
//public delegate void ButtonClickedEventHandler(object sender, EventArgs e);

// Declare a class with an event of the delegate type.
public class Button
{
    public event EventHandler? Clicked;
    //public event ButtonClickedEventHandler? Clicked;
    // In the class that raises the event, create a method to invoke the event.
    private void button1_Click(object sender, System.EventArgs e)
    {
        //.....
    }
    public void OnClicked()
    {
        if (Clicked != null)
        {
            // Invoke the event by calling the delegate.
            //this : siapa yang mengirim event (men-trigger) - diri sendiri (class button)
            //EventArgs: handler (yang menangani) - Empty (ga mau ada info tambahan)
            Clicked(this, EventArgs.Empty);
        }
    }
}

// Declare another class with a method that has the same signature as the delegate.
// This method will be the event handler.
public class Form
{
    public void HandleButtonClick(object sender, EventArgs e)
    {
        Console.WriteLine("Button was clicked!");
    }
}

public static class Program
{
    // In the main program, create an instance of the Button class and subscribe to the Clicked event.
    public static void Main()
    {
        Form form = new Form();
        Button button = new Button();
        //kalau button diklik, akan memerintahkan form untuk panggil event HandleButtonClick
        button.Clicked += form.HandleButtonClick;
        // Finally, raise the event by calling the event invoker method.
        //Isi event dengan handler : 
        button.OnClicked();
    }
}