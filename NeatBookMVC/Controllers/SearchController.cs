using Microsoft.AspNetCore.Mvc;

namespace NeatBookMVC.Controllers
{
    public class SearchController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
