namespace CalculatorLib;
public class GameController {
    public Dictionary<Color, IPlayer> _playerColors = new Dictionary<Color, IPlayer>();
    public void AddPlayer(IPlayer newPlayer, Color color)
        {
            if (newPlayer != null && color != Color.None)
            {
                foreach (var item in _playerColors)
                {
                    if (color == item.Key)
                    {
                        //
                    }
                    else
                    {
                        _playerColors.TryAdd(color, new Player(newPlayer.PlayerName));
                    }
                }
            }
        }
}