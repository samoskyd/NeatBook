using Microsoft.AspNetCore.Mvc;
using NeatBookMVC.MockData;

namespace NeatBookMVC.Controllers
{
    // BookDetailsController

    public class BooksController : Controller
    {
        public IActionResult Index()
        {
            var mockData = new MockBookDetails();
            var model = mockData.GenerateMockData();
            return View(model);
        }
    }
}
