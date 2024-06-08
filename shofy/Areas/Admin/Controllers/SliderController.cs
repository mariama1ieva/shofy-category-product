using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using shofy.Data;
using shofy.Models;

namespace shofy.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SliderController : Controller
    {

        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<SliderSliderInfo> model = await _context.Sliders.ToListAsync();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return BadRequest();

            SliderSliderInfo slider = await _context.Sliders.FirstOrDefaultAsync(m => m.Id == id);

            if (slider == null) return NotFound();



            return View(slider);
        }

        [HttpGet]

        public async Task<IActionResult> Create()
        {
            return View();
        }




    }
}
