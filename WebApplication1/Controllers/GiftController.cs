using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presents.Data.Entities;
using Presents.Data;
using Microsoft.EntityFrameworkCore;

namespace PresentsWebApp.Controllers
{
    public class GiftController : Controller
    {
        private readonly PresentsDbContext context;
        public GiftController(PresentsDbContext context)
        {
            this.context = context;
        }
        public async Task<IActionResult> Index()
        {
            var gifts = await context.Gifts.Include(x => x.Category).ToListAsync();
            return View(gifts);
        }
        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(context.Categories, "ID", "Name");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Gift gift)
        {
            await context.Gifts.AddAsync(gift);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var gift = context.Gifts.Find(id);
            if (gift == null)
            {
                return NotFound();
            }
            context.Gifts.Remove(gift);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Download()
        {
            var count = await context.Gifts.CountAsync();
            if (count == 0)
            {
                return NotFound();
            }
            Random random = new Random();
            int r = random.Next(0, count);
            var gift = await context.Gifts.Skip(r).FirstOrDefaultAsync();
            gift.IsTaken = true;
            return View(gift);
        }
    }
}
