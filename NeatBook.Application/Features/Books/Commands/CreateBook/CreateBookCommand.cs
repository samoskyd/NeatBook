using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Commands.CreateBook
{

    public class CreateBookCommand : IRequest
    {
        public Book Book { get; set; }
        public CreateBookCommand(Book book)
        {
            Book = book;
        }
    }

    public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand>
    {
        private readonly NeatBookDbContext _context;
        public CreateBookCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(CreateBookCommand command, CancellationToken cancellationToken)
        {
            _context.Books.Add(command.Book);
            _context.SaveChanges();

            return Unit.Task;
        }
    }
}
