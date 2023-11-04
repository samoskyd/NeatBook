using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetTenArticles;
using NeatBook.Application.Features.Books.Queries.GetTenBooks;
using NeatBook.Domain.Entities;
using NeatBookMVC.Models.CompositeViewModels;

namespace NeatBookMVC.Controllers
{
    public class FeedController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public FeedController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            var tenBooks = await _mediator.Send(new GetTenBooksQuery());
            var tenArticles = await _mediator.Send(new GetTenArticlesQuery());

            var model = new FeedViewModel
            {
                Articles = tenArticles,
                Books = tenBooks
            };

            return View(model);
        }
    }
}
