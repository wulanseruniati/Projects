using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers;
public class CategoryController : Controller
{
    private readonly Database _context;

    public CategoryController(Database context)
    {
        _context = context;
    }
    public IActionResult Index()
    {
        List<Category> categories = _context.Categories.ToList();
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Category category)
    {
        _context.Categories.Add(category);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public IActionResult Edit(int? id)
    {
        if (id is null || id == 0)
        {
            return NotFound();
        }
        Category? category = _context.Categories.Find(id);
        if (category is not null)
        {
            return View(category);
        }
        else
        {
            return NotFound();
        }
    }
    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
        Category existingComponent = _context.Categories.Find(category.CategoryId);
        // Update properties of existingComponent with values from componentDTO
        existingComponent.CategoryName = category.CategoryName;
        existingComponent.Description = category.Description;
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
    public IActionResult Delete()
    {
        return View();
    }
}