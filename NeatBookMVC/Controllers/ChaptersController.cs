using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Application.Features.Chapters.Commands.UpdateChapter;
using NeatBook.Application.Features.Chapters.Queries.GetChapterById;
using NeatBook.Application.Features.Chapters.Queries.GetChaptersByBook;
using NeatBook.Application.Features.Chapters.Queries.GetFirstChapterIdByBook;
using NeatBook.Application.Features.Chapters.Queries.GetNextChapter;
using NeatBook.Application.Features.Chapters.Queries.GetPreviousChapter;
using NeatBook.Application.Features.Users.Commands.UpdateUser;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Chapters;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.Controllers
{
    public class ChaptersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ChaptersController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> List(int bookId)
        {
            var chapters = await _mediator.Send(new GetChaptersByBookQuery(bookId));
            var model = new ChapterListViewModel
            {
                Chapters = chapters,
                BookId = bookId
            };

            return View(model);
        }

        public async Task<IActionResult> FirstChapterDetails(int bookId)
        {
            var firstChapterId = await _mediator.Send(new GetFirstChapterIdByBookQuery(bookId));

            return RedirectToAction("Details", new { id = firstChapterId });
        }
        
        public async Task<IActionResult> NextChapterDetails(int id)
        {
            var nextChapterId = await _mediator.Send(new GetNextChapterQuery(id));

            return RedirectToAction("Details", new { id = nextChapterId });
        }
        
        public async Task<IActionResult> PreviousChapterDetails(int id)
        {
            var previousChapterId = await _mediator.Send(new GetPreviousChapterQuery(id));

            return RedirectToAction("Details", new { id = previousChapterId });
        }


        public async Task<IActionResult> Details(int id)
        {
            var chapter = await _mediator.Send(new GetChapterByIdQuery(id));

            if (chapter == null)
            {
                return NotFound();
            }

            ChapterDetailsViewModel viewModel = _mapper.Map<ChapterDetailsViewModel>(chapter);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var chapter = await _mediator.Send(new GetChapterByIdQuery(id));

            ChapterDto model = _mapper.Map<ChapterDto>(chapter);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(ChapterDto model)
        {
            if (ModelState.IsValid)
            {
                var chapter = _mapper.Map<Chapter>(model);
                await _mediator.Send(new UpdateChapterCommand(chapter));

                return RedirectToAction("List");
            }

             return View(model);
        }
    }
}
