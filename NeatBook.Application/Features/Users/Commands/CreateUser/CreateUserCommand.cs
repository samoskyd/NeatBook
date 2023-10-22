using NeatBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NeatBook.Infrastructure.Contexts;

namespace NeatBook.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest
    {
        public User User { get; set; }
        public CreateUserCommand(User user) 
        {
            User = user;
        }
    }

    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand>
    {
        private readonly NeatBookDbContext _context;
        public CreateUserCommandHandler(NeatBookDbContext context) 
        {
            _context = context;
        }

        public Task Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            _context.Users.Add(command.User);
            _context.SaveChanges();
            
            return Unit.Task;
        }
    }
}
