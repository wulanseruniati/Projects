public interface IDisc
{
    Guid DiscId {get;}
    Color DiscColor {get;}
    bool FlipDisc(Color discColor);
}