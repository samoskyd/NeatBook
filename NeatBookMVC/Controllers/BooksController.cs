using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Articles.Queries.GetArticleById;
using NeatBook.Application.Features.Books.Commands.UpdateBook;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Application.Features.Users.Commands.UpdateUser;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Articles;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.Controllers
{
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

            BookDetailsViewModel viewModel = _mapper.Map<BookDetailsViewModel>(book);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var book = await _mediator.Send(new GetBookByIdQuery(id));

            BookDto model = _mapper.Map<BookDto>(book);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(BookDto model)
        {
            if (ModelState.IsValid)
            {
                var book = _mapper.Map<Book>(model);
                await _mediator.Send(new UpdateBookCommand(book));

                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}
