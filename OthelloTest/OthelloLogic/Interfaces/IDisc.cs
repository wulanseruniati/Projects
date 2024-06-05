namespace OthelloLogic
{
    public interface IDisc
    {
        public Guid DiscId { get; }
        public Color Color { get; }
        public void SetColor(Color color);
    }
}
