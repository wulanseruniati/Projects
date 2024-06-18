using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMapper _map;
    private readonly Database _db;
    public CategoryController(Database db, IMapper map)
    {
        _db = db;
        _map = map;
    }

    [HttpGet]
    public IActionResult GetCategory()
    {
        var categories = _db.Categories.ToList();
        IEnumerable<CategoryDTO> categoryDTOs = _map.Map<IEnumerable<CategoryDTO>>(categories);
        return Ok(new { categoryDTOs });
    }


    [HttpGet("{id}")]
    public IActionResult GetCategoryById(int id)
    {
        var categories = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)
                          .FirstOrDefault();
        CategoryDTO category = _map.Map<CategoryDTO>(categories);
        /* Assuming _db is your database context and CategoryToDTO is a method to convert Category entity to a DTO
        var category = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => CategoryToDTO(x))    // Convert to DTO
                          .FirstOrDefault();    // Get the first matching category or null*/

        if (category == null)
        {
            return NotFound();    // Return 404 if category not found
        }

        return Ok(category);    // Return the found category
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
        if (category1 == null)
        {
            return NotFound($"Id {id} not found.");
        }
        category1.CategoryName = category.CategoryName;
        category1.Description = category.Description;
        _db.SaveChanges();
        return Ok(category1);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteCategory(int id)
    {
        var category1 = _db.Categories
                          .Where(x => x.CategoryId == id)    // Filter by id
                          .Select(x => x)    // Convert to DTO
                          .FirstOrDefault(); 
        if (category1 == null)
        {
            return NotFound($"Id {id} not found.");
        }
        _db.Categories.Remove(category1);
        _db.SaveChanges();
        return Ok();
    }
}