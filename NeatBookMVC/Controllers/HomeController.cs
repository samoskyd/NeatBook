using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBookMVC.Models;
using System.Diagnostics;

namespace NeatBookMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public IActionResult Index()
        {
            // books, articles and users filled from application layer
            // filling view model with these data parts
            // returning View with this model
            return View();
        }
    }
}