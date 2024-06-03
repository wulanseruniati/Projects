namespace OthelloLogic
{
    public class Disc
    {
        public Color Color { get; private set; }
        public Disc(Color color) {
            Color = color;
        }
        private static Direction[] dirs = new Direction[]
        {
            Direction.north, Direction.south, Direction.east, Direction.west,
            Direction.northEast, Direction.southEast,
            Direction.southWest, Direction.northWest
        };
        //design pattern prototype
        public Disc Copy() {
            return new Disc(Color);
        }
        //can place inside the board and only when the position is empty
        public static bool CanPlaceNext(Position pos, Board board)
        {
            return Board.IsInsideBoard(pos) && board.IsEmpty(pos);
        }

        public bool CanChangeColor(Position pos, Board board)
        {
            if(!Board.IsInsideBoard(pos) || board.IsEmpty(pos))
            {
                return false;
            }
            return board[pos].Color != Color;
        }

        private IEnumerable<PossiblePosition> LinearPlacing(Position from, Board board)
        {
            foreach (Direction linear_dir in new Direction[] { Direction.south, Direction.north, Direction.west, Direction.east })
            {
                Position to = from + linear_dir;
                //if there's placed disc with the same color
                if (CanChangeColor(to, board) && board.IsEmpty(to + linear_dir))
                {
                    yield return new PossiblePosition(from, to +linear_dir);
                }
            }
        }

        private IEnumerable<PossiblePosition> DiagonalPlacing(Position from, Board board)
        {
            foreach (Direction dir in new Direction[] {Direction.west, Direction.east})
            {
                foreach (Direction linear_dir in new Direction[] { Direction.south, Direction.north })
                {
                    Position to = from + linear_dir + dir;
                    if(CanChangeColor(to,board))
                    {
                        yield return new PossiblePosition(from, to);
                    }
                }                    
            }
        }

        public IEnumerable<PossiblePosition> GetPossiblePlacing(Position from, Board board)
        {
            return LinearPlacing(from,board).Concat(DiagonalPlacing(from, board));
        }

        /*public Enumerable<PossiblePosition> GetPossiblePositions(Position from, Board board)
        {
            return new Enumerable<PossiblePosition>(from, from);
        }*/

        private IEnumerable<Position> PlacePositionsInDir(Position from, Board board, Direction dir)
        {
            for (Position pos = from+dir; Board.IsInsideBoard(pos); pos+=dir)
            {
                if(board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }
                yield break;
            }
        }

        private IEnumerable<Position> PlacePositionsInDirs(Position from, Board board, Direction[] dirs)
        {
            return dirs.SelectMany(dir => PlacePositionsInDir(from, board, dir));
        }
    }
}
