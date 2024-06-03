namespace OthelloLogic
{
    public enum Color
    {
        Black,
        White,
        None
    }

    public static class ColorExtensions
    {
        public static Color Opponent(this Color color)
        {
            return color switch
            {
                Color.White => Color.Black,
                Color.Black => Color.Black,
                _ => Color.None,
            };
        }
    }
}
