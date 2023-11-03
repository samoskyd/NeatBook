using Microsoft.AspNetCore.Mvc;

namespace NeatBookMVC.Controllers
{
    public class ArticlesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
