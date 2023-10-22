using MediatR;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Commands.DeleteBook
{
    public class DeleteBookCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteBookCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand>
    {
        private readonly NeatBookDbContext _context;
        public DeleteBookCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(DeleteBookCommand command, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(a => a.Id == command.Id);
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
