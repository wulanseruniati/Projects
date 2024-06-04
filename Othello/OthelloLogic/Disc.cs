namespace OthelloLogic
{
    public class Disc : IDisc
    {
        public Guid DiscId { get; private set; }
        public Color Color { get; private set; }
        public Disc(Color color) {
            DiscId = Guid.NewGuid();
            Color = color;
        }
        //design pattern prototype
        public Disc Copy() => new Disc(Color); 

        public void SetColor(Color color) => Color = color;
    }
}
