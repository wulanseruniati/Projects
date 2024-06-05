using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace OthelloUI
{
    public static class OthelloCursor
    {
        public static readonly Cursor whiteCursor = LoadCursor("Assets/CursorW.cur");
        public static readonly Cursor blackCursor = LoadCursor("Assets/CursorB.cur");
        private static Cursor LoadCursor(string path)
        {
            Stream stream = Application.GetResourceStream(new Uri(path, UriKind.Relative)).Stream;
            return new Cursor(stream, true);
        }
    }    
}
