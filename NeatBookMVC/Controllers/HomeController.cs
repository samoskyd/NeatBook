using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetTenArticles;
using NeatBook.Application.Features.Books.Queries.GetTenBooks;
using NeatBook.Application.Features.Users.Queries.GetTenUsers;
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

        public async Task<IActionResult> Index()
        {
            var tenBooks = await _mediator.Send(new GetTenBooksQuery());
            var tenUsers = await _mediator.Send(new GetTenUsersQuery());
            var tenArticles = await _mediator.Send(new GetTenArticlesQuery());

            var viewModel = new HomePageViewModel
            {
                Books = tenBooks,
                Articles = tenArticles,
                Users = tenUsers
            };

            return View(viewModel);
        }
    }
}