using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetArticleById;
using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Articles;

namespace NeatBookMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public ArticlesController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> List()
        {
            var model = new ArticleListViewModel
            {
                Articles = new List<Article>()
            };
            // get data of all articles with await

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var article = await _mediator.Send(new GetArticleByIdQuery(id));

            if (article == null)
            {
                return NotFound();
            }

            //add mapper
            var viewModel = new ArticleDetailsViewModel
            {
                Name = article.Name,
                ArticleGenre = article.ArticleGenre,
                Language = article.Language,
                AgeRestrictions = article.AgeRestrictions,
                AuthorRights = article.AuthorRights,
                PublishingDate = article.PublishingDate,
                Text = article.Text
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var article = await _mediator.Send(new GetArticleByIdQuery(id));

            var model = new ArticleDto
            {
                Id = article.Id,
                Name = article.Name,
                Text = article.Text,
                ArticleGenre = article.ArticleGenre,
                Language = article.Language,
                AgeRestrictions = article.AgeRestrictions,
                AuthorRights = article.AuthorRights,
                Published = article.Published
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Form(ArticleDto model)
        {
            if (ModelState.IsValid)
            {
                // find article and update with existing model
                // Correctly redirrect to details
                return RedirectToAction("Index");
            }

            // If the model state is not valid, redisplay the edit form with validation errors
            return View(model);
        }
    }
}
