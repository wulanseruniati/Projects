using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

namespace OthelloUI
{
    /// <summary>
    /// Interaction logic for GameOverMenu.xaml
    /// </summary>
    public partial class GameOverMenu : UserControl
    {
        public event Action<GameOverOption> optionSelected; 
        public GameOverMenu(GameController gameController)
        {
            InitializeComponent();
            WinnerText.Text = GetWinnerText(gameController);
            ReasonText.Text = GetReason(gameController);
        }

        private static string GetWinnerText(GameController gameController)
        {
            //get player name is any
            Dictionary<OthelloLogic.Color, Player> playerData = gameController.LoadPlayerColor("PlayerFile.json");
            string playerBlack = playerData.ContainsKey(OthelloLogic.Color.Black) ? playerData[OthelloLogic.Color.Black].PlayerName : "Black";
            string playerWhite = playerData.ContainsKey(OthelloLogic.Color.White) ? playerData[OthelloLogic.Color.White].PlayerName : "White";
            return gameController.GameWinner switch
            {
                OthelloLogic.Color.White => $"WHITE <{playerWhite}> wins!",
                OthelloLogic.Color.Black => $"BLACK <{playerBlack}> wins!",
                _ => "IT'S A TIE"
            };
        }

        private static string PlayerString(OthelloLogic.Color color)
        {
            return color switch { OthelloLogic.Color.White => "WHITE", OthelloLogic.Color.Black => "BLACK", _ => "" };
        }

        private static string GetReason(GameController gameController)
        {
            Dictionary<OthelloLogic.Color, int> playerScore = gameController.GetDiscCount();
            return "BLACK DISCS: " + playerScore[OthelloLogic.Color.Black] + " .WHITE DISCS: " + playerScore[OthelloLogic.Color.White];
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            optionSelected?.Invoke(GameOverOption.Exit);
        }

        private void Restart_Click(object sender, RoutedEventArgs e)
        {
            optionSelected?.Invoke(GameOverOption.Restart);
        }
    }
}
