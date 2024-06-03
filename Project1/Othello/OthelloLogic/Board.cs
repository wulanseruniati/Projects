namespace OthelloLogic
{
    public class Board
    {
        private readonly Disc[,] _discs = new Disc[GameController.boardsize, GameController.boardsize];
        public Disc this[int row, int col]
        {
            get { return _discs[row, col]; }
            set { _discs[row, col] = value; }
        }

        public Disc this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }
        public static Board Initial()
        {
            Board board = new();
            board.AddStartDiscs();
            return board;
        }
        public void AddStartDiscs()
        {
            this[3, 3] = new Disc(Color.White);
            this[3, 4] = new Disc(Color.Black);
            this[4, 3] = new Disc(Color.Black);
            this[4, 4] = new Disc(Color.White);
        }

        public static bool IsInsideBoard(Position position)
        {
            return position.Row >= 0 && position.Column >= 0 
                && position.Row < GameController.boardsize 
                && position.Column < GameController.boardsize;
        }

        public bool IsEmpty(Position position)
        {
            return this[position] == null;
        }
    }
}

