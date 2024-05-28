public interface IBoard
{
    int BoardSize {get;}
    Tuple<int,int> BoardPosition {get;}
    bool IsPositionAvailable(Tuple<int,int> boardPosition);

    Tuple<int,int> GetPosition();
	bool AddPlayerToBoard(IPlayer player);
	bool RemovePlayerFromBoard(IPlayer player);
    bool TryGetPlayerBoard(IPlayer player, out IDictionary<Tuple<int,int>, Guid>? playerBoard);
    bool AddDiscPosition(Guid discId, Tuple<int,int> position);
	bool UpdateDiscPosition(Guid discId, Tuple<int,int> newPosition);
    bool RemoveHeroPosition(IPlayer player, Guid heroId);
    bool TryGetDiscPosition(IPlayer player, Guid heroId, out Tuple<int,int>? position);
	Tuple<int,int> GetDiscPosition(Guid discId);

}