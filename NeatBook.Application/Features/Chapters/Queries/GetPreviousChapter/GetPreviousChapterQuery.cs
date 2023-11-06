using MediatR;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Queries.GetPreviousChapter
{
    public class GetPreviousChapterQuery : IRequest<int>
    {
        public int CurrentChapterId { get; set; }
        public GetPreviousChapterQuery(int currentChapterId)
        {
            CurrentChapterId = currentChapterId;
        }
    }

    public class GetPreviousChapterQueryHandler : IRequestHandler<GetPreviousChapterQuery, int>
    {
        private readonly NeatBookDbContext _context;
        public GetPreviousChapterQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<int> Handle(GetPreviousChapterQuery request, CancellationToken cancellationToken)
        {
            var currentChapter = _context.Chapters.Where(c => c.Id == request.CurrentChapterId).FirstOrDefault();
            var previousChapter = _context.Chapters
                .Where(c => c.BookId == currentChapter.BookId && c.Order < currentChapter.Order)
                .OrderByDescending(c => c.Order)
                .FirstOrDefault();

            return Task.FromResult(previousChapter.Id);
        }
    }
}
