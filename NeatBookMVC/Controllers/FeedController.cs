using Microsoft.AspNetCore.Mvc;

namespace NeatBookMVC.Controllers
{
    public class FeedController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
