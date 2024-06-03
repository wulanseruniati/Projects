namespace OthelloLogic
{
    public struct Position
    {
        public int Row { get; private set; }
        public int Column { get; private set; }

        public Position(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public void SetPosition(int row, int column)
        {
            Row = row; Column = column; 
        }
        //override equals function
        public override bool Equals(object obj) => obj is Position position && Row == position.Row && Column == position.Column;
        public override int GetHashCode() => HashCode.Combine(Row, Column);
        //overloading operator +, == and !=
        public static bool operator ==(Position left, Position right) => EqualityComparer<Position>.Default.Equals(left,right);
        public static bool operator !=(Position left, Position right) => !(left == right);
    }
}
