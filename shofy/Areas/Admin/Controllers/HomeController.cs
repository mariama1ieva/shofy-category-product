using Microsoft.AspNetCore.Mvc;

namespace shofy.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }



    }
}
