using System;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using OthelloLogic;
using NLog;
using NLog.Config;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.Extensions.Logging;

namespace OthelloUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Image[,] _discImages = new Image[GameController.boardsize, GameController.boardsize];
        private readonly Rectangle[,] _highlights = new Rectangle[GameController.boardsize, GameController.boardsize];
        private List<Position> _placingCache = new List<Position>();

        private GameController _gameController;
        public bool PlayerStatus { get; set; } = false;
        private Position? _selectedPosition = null;
        public MainWindow()
        {
            //Logging
            ILoggerFactory loggerFactory = LoggerFactory.Create(log =>
            { log.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Information);
                //log.AddNLog("nlog.config");
            });
            //Logger logger = LogManager.GetCurrentClassLogger();
            //LogManager.Configuration = new XmlLoggingConfiguration("NLog.config");
            Microsoft.Extensions.Logging.ILogger<MainWindow> logger =
                    loggerFactory.CreateLogger<MainWindow>();
                logger.LogDebug("Debug Message");

            UserInput addUserMenu = new();
            InitializeComponent();
            if(PlayerStatus == false)
            {
                addUserMenu.ShowDialog();
                PlayerStatus = true;
            }
            InitializeBoard();
            //looking for saved data
            OthelloLogic.Color colorLoad = FileManager.LoadCurrentColorData("TurnFile.json");
            if(colorLoad == OthelloLogic.Color.None)
            {
                //start a new game
                _gameController = new GameController();
            }
            else
            {
                //load the game
                _gameController = new GameController(colorLoad);
            }
            //write and read log
            Dictionary<OthelloLogic.Color, Player> playerColors = _gameController.LoadPlayerColor("PlayerFile.json");
            //add player
            foreach (var playerColor in playerColors)
            {
                //writing log games
                if (_gameController.AddPlayer(playerColor.Value, playerColor.Key)) ;
            }
            //log
            Task.Run(() => _gameController.WriteLogMessage("log.txt", $"Last game started at {DateTime.Now}. Player black {playerColors[OthelloLogic.Color.Black].PlayerName}," +
                $" player white {playerColors[OthelloLogic.Color.White].PlayerName} joined at {DateTime.Now}"));

            //gameplay for debugging
            _gameController.WriteLogMessage("log2.txt", "Start logging at " + DateTime.Now);

            DrawBoard(_gameController);
            SetCursor(_gameController.CurrentColor);
            CachePlacings();
        }

        public void SetPlayerStatus(bool playerStatus)
        {
            PlayerStatus = playerStatus;
        }

        private void InitializeBoard()
        {
            for (int r = 0; r < GameController.boardsize; r++)
            {
                for (int c = 0; c < GameController.boardsize; c++)
                {
                    Image image = new Image();
                    _discImages[r, c] = image;
                    DiscGrid.Children.Add(image);

                    Rectangle highlight = new Rectangle();
                    _highlights[r, c] = highlight;
                    HighlightGrid.Children.Add(highlight);
                }
            }
        }

        private void DrawBoard(GameController gameController)
        {
            for (int r = 0; r < GameController.boardsize; r++)
            {
                for (int c = 0; c < GameController.boardsize; c++)
                {
                    IDisc[,] discOnBoard = gameController.GetDiscsOnBoard(gameController.Board);
                    IDisc disc = discOnBoard[r, c];
                    _discImages[r, c].Source = Images.GetImage(disc);
                }
            }
        }

        private void BoardGrid_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (IsMenuOnScreen())
            {
                return;
            }
            Point point = e.GetPosition(BoardGrid);
            Position position = ToTilePosition(point);
            //only able to place at the highlighted positions
            foreach (var pos in _placingCache)
            {
                if (pos == position)
                {
                    PlaceToPositionSelected(position);
                    break;
                }
            }
            
        }

        public bool IsMenuOnScreen()
        {
            return MenuContainer.Content != null;
        }
        public void ShowGameOver()
        {
            GameOverMenu gameOverMenu = new(_gameController);
            MenuContainer.Content = gameOverMenu;
            gameOverMenu.optionSelected += option =>
            {
                if (option == GameOverOption.Restart)
                {
                    MenuContainer.Content = null;
                    RestartGame();
                }
                else
                {
                    Application.Current.Shutdown();
                }
            };
        }

        private void RestartGame()
        {
            HideHighlights();
            _placingCache.Clear();
            _gameController = new GameController();
            //write and read log
            Dictionary<OthelloLogic.Color, Player> playerColors = _gameController.LoadPlayerColor("PlayerFile.json");
            //add player
            foreach (var playerColor in playerColors)
            {
                //writing log games
                if (_gameController.AddPlayer(playerColor.Value, playerColor.Key)) ;
            }
            Task.Run(() => _gameController.WriteLogMessage("log.txt", $"Last game started at {DateTime.Now}. Player black {playerColors[OthelloLogic.Color.Black].PlayerName}," +
                $" player white {playerColors[OthelloLogic.Color.White].PlayerName} joined at {DateTime.Now}"));

            //gameplay for debugging
            _gameController.WriteLogMessage("log2.txt", "Start logging at " + DateTime.Now);

            DrawBoard(_gameController);
            SetCursor(_gameController.CurrentColor);
            CachePlacings();
        }

        private void CachePlacings()
        {
            Dictionary<Position, List<Position>> possiblePositions = _gameController.GetLegalMoves();
            _placingCache.Clear();
            if (possiblePositions.Any())
            {
                foreach (var position in possiblePositions)
                {
                    _placingCache.Add(position.Key); 
                }
                ShowHighlights(); 
            }
            //bikin log current color sm board pake tasking
            Task.Run(() => FileManager.CreateCurrentColorData(_gameController.CurrentColor));
            Task.Run(() => FileManager.CreateDiscData(_gameController.GetDiscsOnBoard(_gameController.Board)));
        }

        private void PlaceToPositionSelected(Position position)
        {
            _selectedPosition = null;
            HideHighlights();
            HandlePlacing(position);
        }

        private void HandlePlacing(Position position)
        {
            _gameController.MakeMove(new Position(position.Row, position.Column));
            _gameController.AppendLogMessage("log2.txt",$"{_gameController.CurrentColor} placed disc at {position.Column}; {position.Row}");
            DrawBoard(_gameController);
            SetCursor(_gameController.CurrentColor);
            CachePlacings();
            if (_gameController.IsGameOver())
            {
                ShowGameOver();
            }
        }
        private Position ToTilePosition(Point point)
        {
            double tileSize = BoardGrid.ActualWidth / GameController.boardsize;
            int row = (int)(point.Y / tileSize);
            int col = (int)(point.X / tileSize);
            return new Position(row, col);
        }

        private void ShowHighlights()
        {
            System.Windows.Media.Color color = System.Windows.Media.Color.FromArgb(255, 99, 71, 1);
            foreach (Position position in _placingCache)
            {
                _highlights[position.Row, position.Column].Fill = new SolidColorBrush(color);
                _gameController.AppendLogMessage("log2.txt", $"{_gameController.CurrentColor} highlights disc at {position.Column}; {position.Row}");
            }
        }

        private void HideHighlights()
        {
            foreach (Position position in _placingCache)
            {
                _highlights[position.Row, position.Column].Fill = Brushes.Transparent;
            }
        }

        private void SetCursor(OthelloLogic.Color color)
        {

            if (color == OthelloLogic.Color.White)
            {
                Cursor = OthelloCursor.whiteCursor;
            }
            else
            {
                Cursor = OthelloCursor.blackCursor;
            }
        }
    }
}