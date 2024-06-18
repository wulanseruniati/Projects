using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[ApiController]
public class CategoryController : APIBaseController
{
    public CategoryController(Database db, IMapper map) : base(db, map) {
        //udah di bapaknya
    }
    [HttpGet]
    public IActionResult GetCategory()
    {
        var categories = _db.Categories.ToList();
        IEnumerable<CategoryDTO> categoryDTOs = _map.Map<IEnumerable<CategoryDTO>>(categories);
        return Ok(categoryDTOs);
    }

    [HttpPost]
    public IActionResult CreateCategory(CategoryDTO category)
    {
        Category categoryNew = _map.Map<Category>(category);
        _db.Categories.Add(categoryNew);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, CategoryDTO category)
    {
        var categories = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault();
        Category category1 = _map.Map<Category>(categories);
        
        if(category1 == null)
        {
            return NotFound($"Id {id} not found.");
        }
        category1.CategoryName = category.CategoryName;
        category1.Description = category.Description;
        _db.SaveChanges();
        return Ok(CategoryToDTO(category1));
    }
    
    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category1 = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault(); 
        if(category1 == null)
        {
            return NotFound($"Id {id} not found.");
        }
        _db.Categories.Remove(category1);
        _db.SaveChanges();
        return Ok();
    }

    private static CategoryDTO CategoryToDTO(Category category) =>
       new CategoryDTO
       {
           CategoryName = category.CategoryName,
           Description = category.Description
       };
}