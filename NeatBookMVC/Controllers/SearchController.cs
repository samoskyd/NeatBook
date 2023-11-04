using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetArticlesByName;
using NeatBook.Application.Features.Books.Queries.GetBooksByName;
using NeatBook.Application.Features.Users.Queries.GetUsersByName;
using NeatBookMVC.Models.CompositeViewModels;

namespace NeatBookMVC.Controllers
{
    public class SearchController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public SearchController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Index(string name)
        {
            var books = await _mediator.Send(new GetBooksByNameQuery(name));
            var users = await _mediator.Send(new GetUsersByNameQuery(name));
            var articles = await _mediator.Send(new GetArticlesByNameQuery(name));

            var viewModel = new SearchResultViewModel
            {
                Books = books,
                Articles = articles,
                Users = users
            };

            return View(viewModel);
        }
    }
}
