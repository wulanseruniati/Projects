using System.ComponentModel.DataAnnotations;

public class Board {
    public int BoardSize {get; private set;}
    private Tuple<int,int>? BoardPosition;
    public Board(int boardSize)
	{
        //initialization board position
        for(int i=0; i<boardSize; i++)
        {
            for(int j=0; j<boardSize; j++)
            {
                BoardPosition = new Tuple<int,int>(i,j);
            }
        }
	}
    public bool IsPositionAvailable(Tuple<int,int> boardPosition)
     {
        return true;
     }

    public Tuple<int,int> GetPosition() {
        BoardPosition = new Tuple <int, int>(1, 1);
        return BoardPosition;
    }
	public bool AddPlayerToBoard(IPlayer player) {
        return true;
    }
	public bool RemovePlayerFromBoard(IPlayer player) {
        return true;
    }
    public bool TryGetPlayerBoard(IPlayer player, out IDictionary<Tuple<int,int>, Guid>? playerBoard) {
        BoardPosition = new Tuple <int, int>(1, 1);
        playerBoard = new Dictionary<Tuple<int,int>, Guid>(); 
        return true;
    }
    public bool AddDiscPosition(Guid discId, Tuple<int,int> position) {
        return true;
    }
	public bool UpdateDiscPosition(Guid discId, Tuple<int,int> newPosition) {
        return true;
    }
    public bool RemoveHeroPosition(IPlayer player, Guid heroId) {
        return true;
    }
    public bool TryGetDiscPosition(IPlayer player, Guid heroId, out Tuple<int,int>? position) {
        position = new Tuple <int, int>(1, 1);
        return true;
    }
	public Tuple<int,int> GetDiscPosition(Guid discId) {
        BoardPosition = new Tuple <int, int>(1, 1);
        return BoardPosition;
    }

    //public bool AddPlayerToBoard(IPlayer player) => PiecesPositions.TryAdd(player, new Dictionary<IPosition, Guid>());
}