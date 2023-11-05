using MediatR;
using NeatBook.Application.Features.Articles.Queries.GetAllArticles;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Queries.GetAllBooks
{
    public class GetAllBooksQuery : IRequest<List<Book>>
    {
    }

    public class GetAllBooksQueryHandler : IRequestHandler<GetAllBooksQuery, List<Book>>
    {
        private readonly NeatBookDbContext _context;
        public GetAllBooksQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> Handle(GetAllBooksQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.ToList();

            return Task.FromResult(books);
        }
    }
}
