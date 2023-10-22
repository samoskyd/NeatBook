using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<Book>
    {
        public int Id { get; set; }
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetBookByIdQueryHandler : IRequestHandler<GetBookByIdQuery, Book>
    {
        private readonly NeatBookDbContext _context;
        public GetBookByIdQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<Book> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
        {
            var book = _context.Books.FirstOrDefault(u => u.Id == request.Id);

            return Task.FromResult(book);
        }
    }
}
