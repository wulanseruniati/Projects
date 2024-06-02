public class InventoryItem
{
    private int _itemId;
    private string? _itemName;
    private int _itemStock;

    public int ItemId {
        get { return _itemId; }
    }

    public string ItemName
    {
        get { 
            if(_itemName != null) 
            {
                return _itemName; 
            }
            else {
                return "No Name";
            }
            }
        set
        {
            if (value != null)
            {
                _itemName = value;
            }
        }
    }

    public int ItemStok
    {
        get { return _itemStock; }
        set
        {
            if (value > 0)
            {
                _itemStock = value;
            }
        }
    }

    public InventoryItem(int itemId) {
        _itemId = itemId;
    }

    public int returnStockUpdate(int stok)
    {
        _itemStock += stok;
        return _itemStock;
    } 
    
    public void printInformation(int itemId)
    {
        System.Console.WriteLine("Item Id : "+itemId);
    } 
}