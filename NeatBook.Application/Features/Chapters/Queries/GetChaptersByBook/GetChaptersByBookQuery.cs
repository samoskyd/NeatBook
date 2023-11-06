using MediatR;
using Microsoft.EntityFrameworkCore;
using NeatBook.Application.Features.Chapters.Queries.GetChapterById;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Queries.GetChaptersByBook
{
    public class GetChaptersByBookQuery : IRequest<List<Chapter>>
    {
        public int BookId { get; set; }
        public GetChaptersByBookQuery(int bookId)
        {
            BookId = bookId;
        }
    }

    public class GetChaptersByBookQueryHandler : IRequestHandler<GetChaptersByBookQuery, List<Chapter>>
    {
        private readonly NeatBookDbContext _context;
        public GetChaptersByBookQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Chapter>> Handle(GetChaptersByBookQuery request, CancellationToken cancellationToken)
        {
            var book = _context.Books.Include(b => b.Chapters).FirstOrDefault(u => u.Id == request.BookId);
            var chapterts = book.Chapters.ToList();

            return Task.FromResult(chapterts);
        }
    }
}
