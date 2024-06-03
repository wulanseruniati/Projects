using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using OthelloLogic;

namespace OthelloUI
{
    public static class Images
    {
        private static readonly ImageSource _whiteSources =  LoadImage("Assets/white.png");

        private static readonly ImageSource _blackSources = LoadImage("Assets/black.png");

        private static ImageSource LoadImage(string filePath)
        {
            return new BitmapImage(new Uri(filePath, UriKind.Relative));
        }

        private static ImageSource GetImage(OthelloLogic.Color color) {
            return color switch {
                OthelloLogic.Color.White => _whiteSources,
                OthelloLogic.Color.Black => _blackSources,
                _ => null
            };
        }

        public static ImageSource GetImage(Disc disc)
        {
            return (disc == null) ? null : GetImage(disc.Color);
        }
        /*public static ImageSource GetImage(GameController gameController, Position position)
        {
            ImageSource imageSource;
            OthelloLogic.Color[,] discColor = gameController.GetDiscsOnBoard();
            if (discColor[position.Row,position.Column] == OthelloLogic.Color.White)
            {
                imageSource = GetImage(OthelloLogic.Color.White);
            }
            else if(discColor[position.Row, position.Column] == OthelloLogic.Color.None)
            {
                imageSource = null;
            }
            else
            {
                imageSource = GetImage(OthelloLogic.Color.Black); 
            }
            return imageSource;
        }*/
    }
}
