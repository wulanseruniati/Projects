using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using MVCDemo.Models;

namespace MVCDemo.Controllers;
public class CategoryController : Controller{
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
}