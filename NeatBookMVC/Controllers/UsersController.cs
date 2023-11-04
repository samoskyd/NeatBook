using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using NeatBook.Application.Features.Books.Queries.GetBookById;
using NeatBook.Application.Features.Users.Commands.UpdateUser;
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
        private readonly IMapper _mapper;

        public UsersController(ILogger<HomeController> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<IActionResult> Details(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound();
            }

            UserDetailsViewModel viewModel = _mapper.Map<UserDetailsViewModel>(user);

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Form(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            UserDto model = _mapper.Map<UserDto>(user);

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Form(UserDto model)
        {
            if (ModelState.IsValid)
            {
                var user = _mapper.Map<User>(model);
                await _mediator.Send(new UpdateUserCommand(user));
                
                return RedirectToAction("List");
            }

            return View(model);
        }
    }
}
