using AutoMapper;
using Microsoft.EntityFrameworkCore;

public class ItemModule
{

    private readonly IMapper _map;
    private readonly Database _db;

    public ItemModule(Database db, IMapper map)
    {
        _db = db;
        _map = map;
    }
    public IEnumerable<Item> Get()
    {
        return _db.Items.Include(i => i.Components).ToList();
    }
    public Item? GetById(Guid id)
    {
        var item = _db.Items
                          .Where(x => x.ItemId == id)    // Filter by id
                          .Select(x => x)
                          .Include(i => i.Components)
                          .FirstOrDefault();

        if (item == null)
        {
            return null;    
        }

        return item;
    }
    /*public ItemDTO? GetById(Guid id)
    {
        var item = _db.Items
                          .Where(x => x.ItemId == id)    // Filter by id
                          .Select(x => x)
                          .Include(i => i.Components)
                          .FirstOrDefault();
        ItemDTO itemDTO = _map.Map<ItemDTO>(item);

        if (itemDTO == null)
        {
            return null;    
        }

        return itemDTO;
    }*/
    public bool Create(ItemDTO itemDTO)
    {
        _db.Items.Add(_map.Map<Item>(itemDTO));
        int value = _db.SaveChanges();
        return (value > 0) ? true : false;
    }

    public bool Update(Guid id, ItemDTO itemDTO)
    {
        var item = _db.Items
                          .Where(x => x.ItemId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault();
        Item item1 = _map.Map<Item>(item);
        if (item1 == null)
        {
            return false;
        }
        item1.ItemName = itemDTO.ItemName!;
        item1.Description = itemDTO.Description;
        int value = _db.SaveChanges();
        return (value > 0) ? true : false;
    }

    public bool Delete(Guid id)
    {
        var item = _db.Items
                          .Where(x => x.ItemId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault(); 
        if (item == null)
        {
            return false;
        }
        _db.Items.Remove(item);
        int value = _db.SaveChanges();
        return (value > 0) ? true : false;
    }
}