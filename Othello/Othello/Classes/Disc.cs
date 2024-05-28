public class Disc : IDisc
{
    public Guid DiscId {get; private set;}
    public Color DiscColor {get; private set;}

    public Disc(Color discColor)
    {
        DiscId = Guid.NewGuid();
        DiscColor = discColor;
    }

    public bool FlipDisc(Color discColor)
    {
        if(DiscColor != discColor)
		{
			DiscColor = discColor;
			return true;
		}
        else {
            return false;
        }
    }
}