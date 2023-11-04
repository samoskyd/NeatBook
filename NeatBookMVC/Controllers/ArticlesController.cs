using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Commands.UpdateArticle;
using NeatBook.Application.Features.Articles.Queries.GetArticleById;
using NeatBook.Application.Features.Users.Commands.UpdateUser;
using NeatBook.Domain.Entities;
using NeatBook.Domain.Enums;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Articles;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.Controllers
{
    public class ArticlesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ArticlesController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
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

            ArticleDetailsViewModel viewModel = _mapper.Map<ArticleDetailsViewModel>(article);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var article = await _mediator.Send(new GetArticleByIdQuery(id));

            ArticleDto model = _mapper.Map<ArticleDto>(article);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(ArticleDto model)
        {
            if (ModelState.IsValid)
            {
                var article = _mapper.Map<Article>(model);
                await _mediator.Send(new UpdateArticleCommand(article));

                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}
