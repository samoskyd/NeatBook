using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetArticleById;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.MockData;
using NeatBookMVC.Models.Articles;
using NeatBookMVC.Models.Books;

namespace NeatBookMVC.Controllers
{
    // BookDetailsController

    public class BooksController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public BooksController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> List()
        {
            var model = new BookListViewModel
            {
                Books = new List<Book>()
            };
            // get data of all articles with await

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            if (book == null)
            {
                return NotFound();
            }

            //add mapper
            var viewModel = new BookDetailsViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            var model = new BookDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(BookDto model)
        {
            if (ModelState.IsValid)
            {
                // find book and update with existing model
                // Correctly redirrect to details
                return RedirectToAction("Index");
            }

            // If the model state is not valid, redisplay the edit form with validation errors
            return View(model);
        }
    }
}
