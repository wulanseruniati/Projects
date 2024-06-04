namespace OthelloLogic
{
    public class Board : IBoard
    {
        public Guid BoardId { get; private set; }
        public Board()
        {
            BoardId = new Guid();
        }
    }
}
