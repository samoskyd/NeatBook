using Microsoft.AspNetCore.Mvc;
using NeatBookMVC.MockData;

namespace NeatBookMVC.Controllers
{
    public class BookListController : Controller
    {
        public IActionResult Index()
        {
            var mockData = new MockBookList();
            var model = mockData.GenerateMockData();
            return View(model);
        }
    }
}
