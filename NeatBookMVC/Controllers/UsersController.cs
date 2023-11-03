using Microsoft.AspNetCore.Mvc;

namespace NeatBookMVC.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
