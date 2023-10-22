using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Queries.GetTenBooks
{
    public class GetTenBooksQuery : IRequest<List<Book>>
    {
    }

    public class GetTenBooksQueryHandler : IRequestHandler<GetTenBooksQuery, List<Book>>
    {
        private readonly NeatBookDbContext _context;
        public GetTenBooksQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> Handle(GetTenBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.Take(10).ToList();

            return Task.FromResult(books);
        }
    }
}
