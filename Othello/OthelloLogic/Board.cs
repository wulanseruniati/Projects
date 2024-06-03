namespace OthelloLogic
{
    public class Board
    {
        public Guid BoardId { get; private set; }
        public Board()
        {
            BoardId = new Guid();
        }
    }
}
