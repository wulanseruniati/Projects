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
        return Ok(_db.Categories.ToList());
    }
    [HttpPost]
    public IActionResult PostCategory(Category category)
    {
        _db.Categories.Add(category);
        _db.SaveChanges();
        return Ok();
    }
    [HttpPut("{id}")]
    public async Task<IActionResult> PutCategory(int id, Category category)
    {
        if (id != category.CategoryId)
        {
            return BadRequest();
        }

        _db.Entry(category).State = EntityState.Modified;

        try
        {
            await _db.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoryExists(id))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    private bool CategoryExists(int id)
    {
        return _db.Categories.Any(c => c.CategoryId == id);
    }
}