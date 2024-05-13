public class Player {
    public event EventHandler? Scored;
    
    public void OnScored()
    {
        Scored?.Invoke(this, EventArgs.Empty);
    }
}