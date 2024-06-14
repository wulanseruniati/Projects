using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly Database _db;
    public CategoryController(Database db)
    {
        _db = db;
    }

    [HttpGet]
    public IActionResult GetCategory()
    {
        return Ok(_db.Categories.Select(x => CategoryToDTO(x)).ToList());
    }
    [HttpPost]
    public IActionResult CreateCategory(CategoryDTO category)
    {
        Category categoryNew = new() {
            CategoryName = category.CategoryName,
            Description = category.Description
        };
        _db.Categories.Add(categoryNew);
        _db.SaveChanges();
        return Ok();
    }

    [HttpPut("{id}")]
    public IActionResult UpdateCategory(int id, CategoryDTO category)
    {
        Category category1 = _db.Categories.Find(id);
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
        Category category1 = _db.Categories.Find(id);
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