using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Books.Queries.GetBooksByName
{
    public class GetBooksByNameQuery : IRequest<List<Book>>
    {
        public string Name { get; set; }
        public GetBooksByNameQuery(string name)
        {
            Name = name;
        }
    }

    public class GetBooksByNameQueryHandler : IRequestHandler<GetBooksByNameQuery, List<Book>>
    {
        private readonly NeatBookDbContext _context;
        public GetBooksByNameQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Book>> Handle(GetBooksByNameQuery request, CancellationToken cancellationToken)
        {
            var books = _context.Books.Where(a => a.Name == request.Name).ToList();

            return Task.FromResult(books);
        }
    }
}
