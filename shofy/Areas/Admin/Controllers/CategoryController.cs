using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shofy.Data;
using shofy.Helpers.Extentions;
using shofy.Models;
using shofy.ViewModels;

namespace shofy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoryController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories.OrderByDescending(c => c.Id).ToListAsync();


            return View(categories);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();
            Category category = await _context.Categories.Include(m => m.Products).FirstOrDefaultAsync(c => c.Id == id);
            if (category is null)
            {
                return NotFound();
            }

            CategoryDetailVM model = new()
            {
                Id = category.Id,
                Name = category.Name,
                Image = category.Image,
                productCount = category.Products.Count()

            };

            return View(model);



        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryCreateVM request)

        {
            if (!ModelState.IsValid) return View();

            if (!request.Image.CheckFileSize(500))
            {
                ModelState.AddModelError("Images", "Image size must be max 500 kb");
                return View();
            }

            if (!request.Image.CheckFileFormat("image/"))
            {
                ModelState.AddModelError("Images", "Image format must be img");
                return View();
            }



            string fileName = Guid.NewGuid().ToString() + "-" + request.Image.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/images", fileName);
            await request.Image.SaveFileToLocalAsync(path);




            Category category = new()
            {
                Name = request.Name,
                Image = fileName
            };

            bool existCategory = await _context.Categories.AnyAsync(m => m.Name.Trim() == category.Name.Trim());
            if (existCategory)
            {
                ModelState.AddModelError("Name", "Category already exist");
                return View();
            }

            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.Where(m => m.Id == id).Include(m => m.Products).FirstOrDefaultAsync();
            if (category == null) return NotFound();



            string path = Path.Combine(_webHostEnvironment.WebRootPath, "image", category.Image);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }


            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));


        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return BadRequest();

            Category category = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (category == null) return NotFound();

            return View(new CategoryEditVM { Name = category.Name, Image = category.Image });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryEditVM category, int? id)
        {

            if (!ModelState.IsValid) return View();

            if (id == null) return BadRequest();

            if (!category.Photo.CheckFileSize(500))
            {
                ModelState.AddModelError("Photo", "Image size must be max 500 kb");
                return View(category);
            }

            if (!category.Photo.CheckFileFormat("image/"))
            {
                ModelState.AddModelError("Photo", "Image format must be img");
                return View(category);
            }

            Category existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);

            if (existCategory == null) return NotFound();

            FileExtention.DeleteFileToLocalAsync(Path.Combine(_webHostEnvironment.WebRootPath, "assets/images"), existCategory.Image);

            string fileName = Guid.NewGuid().ToString() + "-" + category.Photo.FileName;
            string path = Path.Combine(_webHostEnvironment.WebRootPath, "assets/images", fileName);
            await category.Photo.SaveFileToLocalAsync(path);

            existCategory.Name = category.Name;
            existCategory.Image = fileName;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }






    }
}
