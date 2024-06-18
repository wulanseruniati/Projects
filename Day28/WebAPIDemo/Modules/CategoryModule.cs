using AutoMapper;

public class CategoryModule
{

    private readonly IMapper _map;
    private readonly Database _db;

    public CategoryModule(Database db, IMapper map)
    {
        _db = db;
        _map = map;
    }
    public IEnumerable<Category> Get()
    {
        return _db.Categories.ToList();
    }
    public CategoryDTO? GetById(int id)
    {
        var categories = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)
                          .FirstOrDefault();
        CategoryDTO category = _map.Map<CategoryDTO>(categories);

        if (category == null)
        {
            return null;    // Return 404 if category not found
        }

        return category;
    }
    public bool Create(CategoryDTO category)
    {
        _db.Categories.Add(_map.Map<Category>(category));
        int value = _db.SaveChanges();
        return (value > 0) ? true : false;
    }

    public bool Update(int id, CategoryDTO category)
    {
        var categories = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault();
        Category category1 = _map.Map<Category>(categories);
        if (category1 == null)
        {
            return false;
        }
        category1.CategoryName = category.CategoryName;
        category1.Description = category.Description;
        int value = _db.SaveChanges();
        return (value > 0) ? true : false;
    }
}