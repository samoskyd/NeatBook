using MediatR;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Users.Commands.DeleteUser
{
    public class DeleteUserCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteUserCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand>
    {
        private readonly NeatBookDbContext _context;
        public DeleteUserCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(DeleteUserCommand command, CancellationToken cancellationToken)
        {
            var user = _context.Users.FirstOrDefault(a => a.Id == command.Id);
            _context.Users.Remove(user);
            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
