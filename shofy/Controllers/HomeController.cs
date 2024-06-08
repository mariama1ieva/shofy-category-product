using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shofy.Data;
using shofy.ViewModels;


namespace shofy.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders.ToListAsync();
            var categories = await _context.Categories.Include(m => m.Products).ToListAsync();



            HomeVM model = new()
            {
                Sliders = sliders,
                Categories = categories,

            };

            return View(model);
        }


    }
}
