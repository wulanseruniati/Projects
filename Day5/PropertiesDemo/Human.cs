public class Human
{
    //field
    public string nama = "Test"; //tidak disarankan
    //properties
    public int ID { get; private set; } //cuma bisa di-get, set nya private
    public int id { get; } //cuma bisa di-get

    private int _balance;
    public int Balance
    {
        get { return _balance; }
        set
        {
            if (value > 0 && value <= 10000000)
            {
                _balance = value;
            }
            else {
                System.Console.WriteLine("Balance value is not allowed. Balance remains unchanged");
            }
        }
    }
    public void SetBalance(int balance)
    {
        Balance = balance;
    }
}