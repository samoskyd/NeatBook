using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Commands.PublishBook
{
    public class PublishBookCommand : IRequest
    {
        public Book Book { get; set; }
        public PublishBookCommand(Book book)
        {
            Book = book;
        }
    }

    public class PublishBookCommandHandler : IRequestHandler<PublishBookCommand>
    {
        private readonly NeatBookDbContext _context;
        public PublishBookCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(PublishBookCommand command, CancellationToken cancellationToken)
        {
            var dbBook = _context.Books.FirstOrDefault(a => a.Id == command.Book.Id);

            bool published = command.Book.Published;
            dbBook.Published = published;
            
            if (published) dbBook.PublishingDate = DateTime.UtcNow;
            else dbBook.PublishingDate = null;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
