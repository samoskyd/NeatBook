using Microsoft.AspNetCore.Mvc;

namespace NeatBookMVC.Controllers
{
    public class ChaptersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
