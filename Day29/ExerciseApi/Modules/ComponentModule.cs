using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

public class ComponentModule
{
    private readonly IMapper _map;
    private readonly Database _db;

    public ComponentModule(Database db, IMapper map)
    {
        _db = db;
        _map = map;
    }

    public IEnumerable<ComponentDTO> Get()
    {
        var components = _db.Components.ToList();
        return _map.Map<IEnumerable<ComponentDTO>>(components);
    }

    public ComponentDTO GetById(int id)
    {
        var component = _db.Components.FirstOrDefault(x => x.ComponentID == id);
        return _map.Map<ComponentDTO>(component);
    }

    public bool Create(ComponentDTO componentDTO)
    {
        var component = _map.Map<Component>(componentDTO);
        _db.Components.Add(component);
        return _db.SaveChanges() > 0;
    }

    public bool Update(int id, ComponentDTO componentDTO)
    {
        var existingComponent = _db.Components.FirstOrDefault(x => x.ComponentID == id);
        if (existingComponent == null)
        {
            return false;
        }

        // Update properties of existingComponent with values from componentDTO
        existingComponent.ComponentName = componentDTO.ComponentName!;
        existingComponent.ComponentDesc = componentDTO.ComponentDesc;

        return _db.SaveChanges() > 0;
    }

    public bool Delete(int id)
    {
        var component = _db.Components.FirstOrDefault(x => x.ComponentID == id);
        if (component == null)
        {
            return false;
        }

        _db.Components.Remove(component);
        return _db.SaveChanges() > 0;
    }
}
