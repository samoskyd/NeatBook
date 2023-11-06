using MediatR;
using Microsoft.EntityFrameworkCore;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Queries.GetNextChapter
{
    public class GetNextChapterQuery : IRequest<int>
    {
        public int CurrentChapterId { get; set; }
        public GetNextChapterQuery(int currentChapterId)
        {
            CurrentChapterId = currentChapterId;
        }
    }

    public class GetNextChapterQueryHandler : IRequestHandler<GetNextChapterQuery, int>
    {
        private readonly NeatBookDbContext _context;
        public GetNextChapterQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(GetNextChapterQuery request, CancellationToken cancellationToken)
        {
            var currentChapter = _context.Chapters.Where(c => c.Id == request.CurrentChapterId).FirstOrDefault();
            var nextChapter = _context.Chapters
                .Where(c => c.BookId == currentChapter.BookId && c.Order > currentChapter.Order)
                .OrderBy(c => c.Order)
                .FirstOrDefault();

            return Task.FromResult(nextChapter.Id);
        }
    }
}
