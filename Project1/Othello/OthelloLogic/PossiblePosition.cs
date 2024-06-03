namespace OthelloLogic
{
    public class PossiblePosition
    {
        public Position FromPos { get; private set; }
        public Position PlacePos { get; private set; }

        public PossiblePosition(Position fromPos, Position placePos)
        {
            FromPos = fromPos;
            PlacePos = placePos;
        }

        public void Execute(Board board)
        {
            Disc disc = board[FromPos];
            board[PlacePos]= disc;
            //also turn yah guys
        }
    }
}
