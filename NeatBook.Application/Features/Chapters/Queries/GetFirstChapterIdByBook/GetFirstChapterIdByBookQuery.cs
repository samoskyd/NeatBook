using MediatR;
using Microsoft.EntityFrameworkCore;
using NeatBook.Application.Features.Chapters.Queries.GetChaptersByBook;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Queries.GetFirstChapterIdByBook
{
    public class GetFirstChapterIdByBookQuery : IRequest<int>
    {
        public int BookId { get; set; }
        public GetFirstChapterIdByBookQuery(int bookId)
        {
            BookId = bookId;
        }
    }

    public class GetFirstChapterIdByBookQueryHandler : IRequestHandler<GetFirstChapterIdByBookQuery, int>
    {
        private readonly NeatBookDbContext _context;
        public GetFirstChapterIdByBookQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(GetFirstChapterIdByBookQuery request, CancellationToken cancellationToken)
        {
            var book = _context.Books.Include(b => b.Chapters).FirstOrDefault(u => u.Id == request.BookId);
            var chapter = book.Chapters.FirstOrDefault(u => u.Order == 1);
            var chapterId = chapter.Id;
            return Task.FromResult(chapterId);
        }
    }
}
