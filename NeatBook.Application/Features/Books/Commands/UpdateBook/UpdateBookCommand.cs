using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Commands.UpdateBook
{
    public class UpdateBookCommand : IRequest
    {
        public Book Book { get; set; }
        public UpdateBookCommand(Book book)
        {
            Book = book;
        }
    }

    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand>
    {
        private readonly NeatBookDbContext _context;
        public UpdateBookCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(UpdateBookCommand command, CancellationToken cancellationToken)
        {
            var dbBook = _context.Books.FirstOrDefault(a => a.Id == command.Book.Id);

            dbBook.Name = command.Book.Name;
            dbBook.BookGenre = command.Book.BookGenre;
            dbBook.Language = command.Book.Language;
            dbBook.Description = command.Book.Description;
            dbBook.BookStatus = command.Book.BookStatus;
            dbBook.AuthorRights = command.Book.AuthorRights;
            dbBook.AgeRestriction = command.Book.AgeRestriction;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
