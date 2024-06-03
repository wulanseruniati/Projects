using OthelloLogic;
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
using System.Windows.Shapes;

namespace OthelloUI
{
    /// <summary>
    /// Interaction logic for UserInput.xaml
    /// </summary>
    public partial class UserInput : Window
    {
        public event Action<string> GetPlayerBlack;
        public event Action<string> GetPlayerWhite;
        public UserInput()
        {
            InitializeComponent();        
        }

        private void Start_Click(object sender, RoutedEventArgs e)
        {
            string playerBlack = PlayerBlack.Text.ToString();
            string playerWhite = PlayerWhite.Text.ToString();
            //create log
            Player black = new Player(playerBlack);
            Player white = new Player(playerWhite);
            Dictionary<OthelloLogic.Color, IPlayer> playerColor = new();
            playerColor.Add(OthelloLogic.Color.White, white);
            playerColor.Add(OthelloLogic.Color.Black, black);
            FileManager.CreatePlayerData(playerColor);
            //create player none
            FileManager.CreateCurrentColorData(OthelloLogic.Color.None);
            //end create log
            GetPlayerBlack?.Invoke(playerBlack);
            GetPlayerWhite?.Invoke(playerWhite);
            this.Hide();
        }

        private void ExitGame_Click(object sender, RoutedEventArgs e)
        {
            //Application.Current.Shutdown();
            //load data
            this.Hide();
        }
    }
}
