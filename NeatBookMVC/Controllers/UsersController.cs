using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Application.Features.Users.Queries.GetUserById;
using NeatBook.Domain.Entities;
using NeatBookMVC.DTOs;
using NeatBookMVC.Models.Books;
using NeatBookMVC.Models.Users;

namespace NeatBookMVC.Controllers
{
    public class UsersController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public UsersController(ILogger<HomeController> logger, IMediator mediator)
        {
            _mediator = mediator;
            _logger = logger;
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound();
            }

            //add mapper
            var viewModel = new UserDetailsViewModel();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            var model = new UserDto();

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Form(UserDto model)
        {
            if (ModelState.IsValid)
            {
                // find user and update with existing model
                // Correctly redirrect to details
                return RedirectToAction("Index");
            }

            // If the model state is not valid, redisplay the edit form with validation errors
            return View(model);
        }
    }
}
