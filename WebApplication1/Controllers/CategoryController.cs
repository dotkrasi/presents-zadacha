using Microsoft.AspNetCore.Mvc;
using Presents.Data.Entities;
using Presents.Data;
using Microsoft.EntityFrameworkCore;

namespace PresentsWebApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly PresentsDbContext context;
        public CategoryController(PresentsDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await context.Categories.ToListAsync();
            return View(categories);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            await context.Categories.AddAsync(category);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var category = context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            context.Categories.Remove(category);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}
