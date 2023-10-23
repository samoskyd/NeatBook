using Microsoft.AspNetCore.Mvc;
using NeatBookMVC.MockData;

namespace NeatBookMVC.Controllers
{
    public class UserProfileController : Controller
    {
        public IActionResult Index()
        {
            var mockData = new MockUserProfile();
            var model = mockData.GenerateMockData();
            return View(model);
        }
    }
}
