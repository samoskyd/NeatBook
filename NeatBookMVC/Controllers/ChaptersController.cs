using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Application.Features.Chapters.Queries.GetChapterById;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Chapters;

namespace NeatBookMVC.Controllers
{
    public class ChaptersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public ChaptersController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> List()
        {
            var model = new ChapterListViewModel
            {
                Chapters = new List<Chapter>()
            };
            // get data of all Chapters with await

            return View(model);
        }

        public async Task<IActionResult> Details(int id)
        {
            var chapter = await _mediator.Send(new GetChapterByIdQuery(id));

            if (chapter == null)
            {
                return NotFound();
            }

            //add mapper
            var viewModel = new ChapterDetailsViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var chapter = await _mediator.Send(new GetChapterByIdQuery(id));

            var model = new ChapterDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(ChapterDto model)
        {
            if (ModelState.IsValid)
            {
                // find Chapter and update with existing model
                // Correctly redirrect to details
                return RedirectToAction("Index");
            }

            // If the model state is not valid, redisplay the edit form with validation errors
            return View(model);
        }
    }
}
