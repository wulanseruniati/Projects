namespace OthelloLogic
{
    public enum Color
    {
        None,
        Black,
        White
    }

    public static class ColorExtensions
    {
        public static Color Opponent(this Color color)
        {
            return color switch
            {
                Color.White => Color.Black,
                Color.Black => Color.White,
                _ => Color.None,
            };
        }
    }
}
