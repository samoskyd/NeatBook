using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Users.Commands.UpdateUser
{

    public class UpdateUserCommand : IRequest
    {
        public User User { get; set; }
        public UpdateUserCommand(User user)
        {
            User = user;
        }
    }

    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand>
    {
        private readonly NeatBookDbContext _context;
        public UpdateUserCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(UpdateUserCommand command, CancellationToken cancellationToken)
        {
            var dbUser = _context.Users.FirstOrDefault(a => a.Id == command.User.Id);

            dbUser.Name = command.User.Name;
            dbUser.Nickname = command.User.Nickname;
            dbUser.Surname = command.User.Surname;
            dbUser.BirthDate = command.User.BirthDate;
            dbUser.UserSex = command.User.UserSex;
            dbUser.BioText = command.User.BioText;
            dbUser.SocialLink = command.User.SocialLink;
            dbUser.Password = command.User.Password;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
