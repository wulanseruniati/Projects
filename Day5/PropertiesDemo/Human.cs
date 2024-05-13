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
        get { return this._balance; }
        set
        {
            if (value < 0)
            {
                System.Console.WriteLine("Low Balance! Jangan ngutang");
            }
            else {
                this._balance = value;
            }
        }
    }
    public void SetBalance(int balance)
    {
        Balance = balance;
    }
}