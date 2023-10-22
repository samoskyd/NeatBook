using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Commands.PublishChapter
{
    public class PublishChapterCommand : IRequest
    {
        public Chapter Chapter { get; set; }
        public PublishChapterCommand(Chapter chapter)
        {
            Chapter = chapter;
        }
    }

    public class PublishChapterCommandHandler : IRequestHandler<PublishChapterCommand>
    {
        private readonly NeatBookDbContext _context;
        public PublishChapterCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(PublishChapterCommand command, CancellationToken cancellationToken)
        {
            var dbChapter = _context.Chapters.FirstOrDefault(a => a.Id == command.Chapter.Id);

            bool published = command.Chapter.Published;
            dbChapter.Published = published;

            if (published) dbChapter.PublishingDate = DateTime.UtcNow;
            else dbChapter.PublishingDate = null;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
