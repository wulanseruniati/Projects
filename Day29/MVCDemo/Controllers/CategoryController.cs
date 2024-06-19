using System.Diagnostics;
using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVCDemo.Models;

namespace MVCDemo.Controllers;
public class CategoryController : Controller
{
    private readonly Database _context;
    private readonly INotyfService _notyf;

    public CategoryController(Database context, INotyfService notyf)
    {
        _context = context;
        _notyf = notyf;
    }
    public IActionResult Index()
    {
        List<Category> categories = _context.Categories.ToList();
        //List<Category> categories = _context.Categories.Include(c => c.CategoryId).ToList();
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
        TempData["Success"] = $"Category '{category.CategoryName}' successfully created!";
        _notyf.Success("Success Notification");
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
        Category existingComponent = _context.Categories.Find(category.CategoryId)!;
        // Update properties of existingComponent with values from componentDTO
        existingComponent.CategoryName = category.CategoryName;
        existingComponent.Description = category.Description;
        await _context.SaveChangesAsync();
        TempData["Success"] = $"Category '{category.CategoryName}' successfully edited!";
        _notyf.Warning($"Category '{category.CategoryName}' successfully edited!");
        return RedirectToAction("Index");
    }
    public IActionResult Delete(int? id)
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
    public async Task<IActionResult> Delete(Category category)
    {
        Category existingComponent = _context.Categories.Find(category.CategoryId)!;
        TempData["Success"] = $"Category '{category.CategoryName}' successfully deleted!";
        _context.Categories.Remove(existingComponent);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
    }
}