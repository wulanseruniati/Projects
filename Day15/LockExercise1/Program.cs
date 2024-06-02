class Program
{
    static object lockObject = new object();
    private Dictionary<Player, int> _playerScore = new Dictionary<Player, int>();
    static void Main()
    {
        Program program = new();
        System.Console.WriteLine("Input player name: ");
        string? nama = Console.ReadLine();
        if (nama != null)
        {
            Player player = new Player(nama);
            Action<Player> initiateScore = program.InitiateScore;

            //running a task in background thread
            Task fetchPlayer = new Task(player.OutputPlayer);
            fetchPlayer.Start();
            //creating a forethread
            Thread initiatingScore = new Thread(() => initiateScore(player));
            initiatingScore.Start();
            //wait until the thread is finished
            initiatingScore.Join();
            //creating a forethread
            Thread addScore = new Thread(() => AddScore(program,player,5));
            Thread substractScore = new Thread(() => SubstractScore(program,player,2));
            addScore.Start();
            substractScore.Start();
            addScore.Join();
            substractScore.Join();
        }
        else
        {
            System.Console.WriteLine("Please input a valid name..");
        }
    }

    static void AddScore(Program program, Player player, int score)
    {
        //locking show score
        if (Monitor.TryEnter(lockObject))
        {
            try
            {
                System.Console.WriteLine("The current score is " + (program._playerScore[player] + score));
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }

    static void SubstractScore(Program program, Player player, int score)
    {
        if (Monitor.TryEnter(lockObject))
        {
            try
            {
                System.Console.WriteLine("The current score is " + (program._playerScore[player] - score));
            }
            finally
            {
                Monitor.Exit(lockObject);
            }
        }
    }

    void InitiateScore(Player player)
    {
        _playerScore.Add(player, 100);
        System.Console.WriteLine("The current score is zero");
    }
}