public class Item {
    public Guid ItemId {get; set;}
    public string ItemName {get; set;} = null!;
    public string Description { get; set; } = null!;
    public IEnumerable<Component> Components { get; set; }

    public Item()
    {
        Components = new List<Component>();
        ItemId = new Guid();
    }
}