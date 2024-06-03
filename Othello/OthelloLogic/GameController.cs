using System.IO;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OthelloLogic
{
    public class GameController
    {
        public readonly int maxPlayer;
        public const int boardsize = 8;
        public GameState CurrentGameState { get; private set; } = GameState.INIT;
        public Color CurrentColor { get; private set; }
        public Color GameWinner { get; private set; }
        public Board Board { get; private set; }
        //private Disc[,] _discsOnBoard;
        private Dictionary<Color, IPlayer> _playerColors = new Dictionary<Color, IPlayer>();
        private Dictionary<Board, List<IPlayer>> _playersOnBoard;
        private Dictionary<Color, int> _discCount;
        private Dictionary<Position, List<Position>> _legalMoves;
        private Dictionary<Board, Disc[,]> _discsOnBoard = new Dictionary<Board, Disc[,]>();
        private bool _hasSkipped = false;
        //default delegates
        public Action<string, string> WriteLogMessage;
        public Action<string, string> AppendLogMessage;
        public Func<string, string> ReadLogMessage;
        public Action<Dictionary<Color, IPlayer>> AppendPlayerColor;
        public Func<string, Dictionary<Color, Player>> LoadPlayerColor;
        //getter for all _playerColors
        public Dictionary<Color, IPlayer> GetAllPlayersColor()
        {
            return _playerColors;
        }
        //getter for certain _playerColors
        public IPlayer GetPlayersColor(Color color)
        {
            return _playerColors[color];
        }
        //setter for _playerColors
        public bool SetPlayerColor(Dictionary<Color, IPlayer> playerColor)
        {
            bool safeToInsert = false;
            foreach (Color color in _playerColors.Keys)
            {
                if (_playerColors.ContainsKey(color))
                    safeToInsert = false;
                safeToInsert = true;
            }
            return safeToInsert;
        }

        //getter for all _playersOnBoard
        public Dictionary<Board, List<IPlayer>> GetAllPlayersOnBoard()
        {
            return _playersOnBoard;
        }
        //getter for certain _playersOnBoard
        public List<IPlayer> GetPlayersOnBoard(Board board)
        {
            return _playersOnBoard[board];
        }
        //setter for _playersOnBoard
        public void SetPlayersOnBoard(Dictionary<Board, List<IPlayer>> playersOnBoard)
        {
            _playersOnBoard = playersOnBoard;
        }

        // Getter method for _discsOnBoard
        public Dictionary<Board, Disc[,]> GetAllDiscsOnBoard()
        {
            return _discsOnBoard;
        }
        public Disc[,] GetDiscsOnBoard(Board board)
        {
            return _discsOnBoard[board];
        }

        // Setter method for _discsOnBoard
        public void SetDiscsOnBoard(Dictionary<Board, Disc[,]> value)
        {
            _discsOnBoard = value;
        }

        // Getter method for _discCount
        public Dictionary<Color, int> GetDiscCount()
        {
            return _discCount;
        }
        public int GetDiscCountByKey(Color color)
        {
            return _discCount[color];
        }

        // Setter method for _discCount
        public void SetDiscCount(Dictionary<Color, int> value)
        {
            _discCount = value;
        }

        // Getter method for _legalMoves
        public Dictionary<Position, List<Position>> GetLegalMoves()
        {
            return _legalMoves;
        }
        public List<Position> GetLegalMovesByKey(Position position)
        {
            return _legalMoves[position];
        }

        // Setter method for _legalMoves
        public void SetLegalMoves(Dictionary<Position, List<Position>> value)
        {
            _legalMoves = value;
        }
        //constructor to start a new game
        public GameController(int maxPlayer = 2)
        {
            Board = new Board();
            _discsOnBoard.Add(Board, new Disc[boardsize, boardsize]);
            for (int row = 0; row < boardsize; row++)
            {
                for (int column = 0; column < boardsize; column++)
                {
                    Disc discOnBoard = new Disc(Color.None);
                    _discsOnBoard[Board][row, column] = discOnBoard;
                }
            }
            _discsOnBoard[Board][3, 3].SetColor(Color.White);
            _discsOnBoard[Board][3, 4].SetColor(Color.Black);
            _discsOnBoard[Board][4, 3].SetColor(Color.Black);
            _discsOnBoard[Board][4, 4].SetColor(Color.White);

            _discCount = new Dictionary<Color, int>()
            {
                {Color.Black,2},
                {Color.White,2}
            };

            CurrentColor = Color.Black;
            _legalMoves = FindLegalMoves(CurrentColor);
            //assign method to default delegates
            WriteLogMessage = FileManager.WriteLog;
            AppendLogMessage = FileManager.AppendLog;
            ReadLogMessage = FileManager.ReadLog;
            AppendPlayerColor = FileManager.CreatePlayerData;
            LoadPlayerColor = FileManager.LoadPlayerData;
        }
        //constructor to load data
        public GameController(Color currentColor, int maxPlayer = 2)
        {
            Board = new Board();
            //loaded data start
            Disc[,] discs = FileManager.LoadDiscData("BoardData.json");
            _discsOnBoard.Add(Board, discs);
            CurrentColor = currentColor;
            //get the data
            int colorBlackCount = OccupiedTilesByColor(Color.Black).Count();
            int colorWhiteCount = OccupiedTilesByColor(Color.White).Count();
            _discCount = new Dictionary<Color, int>()
            {
                {Color.Black,colorBlackCount},
                {Color.White,colorWhiteCount}
            };
            //loaded data end
            _legalMoves = FindLegalMoves(CurrentColor);
            //assign method to default delegates
            WriteLogMessage = FileManager.WriteLog;
            AppendLogMessage = FileManager.AppendLog;
            ReadLogMessage = FileManager.ReadLog;
            AppendPlayerColor = FileManager.CreatePlayerData;
            LoadPlayerColor = FileManager.LoadPlayerData;
        }
        //add player and assign the color
        public bool AddPlayer(IPlayer newPlayer, Color color)
        {
            if (newPlayer != null && color != Color.None)
            {
                foreach (var item in _playerColors)
                {
                    if (color == item.Key)
                    {
                        return false;
                    }
                    else
                    {
                        _playerColors.TryAdd(color, new Player(newPlayer.PlayerName));
                    }
                }
                return true;
            }
            else
            {
                return false;
            }
        }
        //return the position of discs that can be captured/ outflanked
        private List<Position> CapturedInDirections(Position position, Color color, int rDelta, int cDelta)
        {
            List<Position> outflanked = new List<Position>();
            int r = position.Row + rDelta;
            int c = position.Column + cDelta;
            while (IsInsideBoard(r, c) && _discsOnBoard[Board][r, c].Color != Color.None)
            {
                if (_discsOnBoard[Board][r, c].Color == color.Opponent())
                {
                    outflanked.Add(new Position(r, c));
                    r += rDelta;
                    c += cDelta;
                }
                else //if _discsOnBoard[r,c] == color 
                {
                    return outflanked;
                }
            }
            return new List<Position>();
        }
        //checking opponent disc in the neighborhood to start capture/outflank discs
        private List<Position> Captured(Position position, Color color)
        {
            List<Position> outflanked = new();
            for (int rDelta = -1; rDelta <= 1; rDelta++)
            {
                for (int cDelta = -1; cDelta <= 1; cDelta++)
                {
                    if (rDelta == 0 && cDelta == 0)
                    {
                        continue;
                    }
                    outflanked.AddRange(CapturedInDirections(position, color, rDelta, cDelta));
                }
            }
            return outflanked;
        }
        //checking if the move is possible
        private bool IsMoveLegal(Color color, Position position, out List<Position> outflanked)
        {
            // discOnBoard = _discsOnBoard[position.Row, position.Column];
            if (_discsOnBoard[Board][position.Row, position.Column].Color != Color.None)
            {
                outflanked = null;
                return false;
            }

            outflanked = Captured(position, color);
            return outflanked.Count > 0;
        }
        //return collection of key (positions where a disc can capture opponent)
        //and value (positions of the captured discs)
        private Dictionary<Position, List<Position>> FindLegalMoves(Color color)
        {
            Dictionary<Position, List<Position>> legalMoves = new();
            for (int r = 0; r < boardsize; r++)
            {
                for (int c = 0; c < boardsize; c++)
                {
                    Position position = new Position(r, c);
                    if (IsMoveLegal(color, position, out List<Position> outflanked))
                    {
                        legalMoves[position] = outflanked;
                    }
                }
            }

            return legalMoves;
        }
        //checking if a coordinate is inside board
        private bool IsInsideBoard(int r, int c)
        {
            return r >= 0 && r < boardsize && c >= 0 && c < boardsize;
        }
        //place disc on the board
        public void MakeMove(Position position)
        {
            if (!_legalMoves.ContainsKey(position))
            {
            }
            Color moveColor = CurrentColor;
            List<Position> outflanked = _legalMoves[position];

            _discsOnBoard[Board][position.Row, position.Column].SetColor(moveColor);
            FlipDiscs(outflanked);
            UpdateDiscCount(moveColor, outflanked.Count);
            ChangeTurn();
        }
        //return the collection of occupied tiles
        public IEnumerable<Position> OccupiedTiles()
        {
            for (int r = 0; r < boardsize; r++)
            {
                for (int c = 0; c < boardsize; c++)
                {
                    //Disc discOnBoard = _discsOnBoard[r, c];
                    if (_discsOnBoard[Board][r, c].Color != Color.None)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }
        //return certain color
        public IEnumerable<Position> OccupiedTilesByColor(Color color)
        {
            for (int r = 0; r < boardsize; r++)
            {
                for (int c = 0; c < boardsize; c++)
                {
                    //Disc discOnBoard = _discsOnBoard[r, c];
                    if (_discsOnBoard[Board][r, c].Color == color)
                    {
                        yield return new Position(r, c);
                    }
                }
            }
        }
        //flip discs that captured/ outflanked
        private void FlipDiscs(List<Position> positions)
        {
            foreach (Position position in positions)
            {
                //Disc flippedDisc = _discsOnBoard[position.Row, position.Column];
                _discsOnBoard[Board][position.Row, position.Column].SetColor(_discsOnBoard[Board][position.Row, position.Column].Color.Opponent());
            }
        }
        //update caught discs value
        private void UpdateDiscCount(Color moveColor, int outflankedCount)
        {
            _discCount[moveColor] += outflankedCount + 1;
            _discCount[moveColor.Opponent()] -= outflankedCount;
        }
        //change the current player to opponent
        private void ChangeCurrentPlayer()
        {
            CurrentColor = CurrentColor.Opponent();
            _legalMoves = FindLegalMoves(CurrentColor);
        }
        //looking for the game winner
        private Color SetGameWinner()
        {
            if (_discCount[Color.Black] > _discCount[Color.White])
            {
                return Color.Black;
            }
            if (_discCount[Color.White] > _discCount[Color.Black])
            {
                return Color.White;
            }
            return Color.None;
        }
        //change turn to opponent
        private void ChangeTurn()
        {
            ChangeCurrentPlayer();
            //testing ending
            //_legalMoves.Clear();

            if (_legalMoves.Count > 0)
            {
                return;
            }

            ChangeCurrentPlayer();
            if (_legalMoves.Count > 0 || IsFullyOccupied())
            {
                CurrentColor = Color.None;
                CurrentGameState = GameState.GAME_END;
                GameWinner = SetGameWinner();
            }
        }
        //checking if all the discs are placed
        private bool IsFullyOccupied()
        {
            IEnumerable<Position> occupied = OccupiedTiles();
            if (occupied.Count() >= 64)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        //checking if the game is over
        public bool IsGameOver() => CurrentGameState == GameState.GAME_END;
    }
}