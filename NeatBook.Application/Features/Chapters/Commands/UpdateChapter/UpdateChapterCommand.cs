using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Commands.UpdateChapter
{
    public class UpdateChapterCommand : IRequest
    {
        public Chapter Chapter { get; set; }
        public UpdateChapterCommand(Chapter chapter)
        {
            Chapter = chapter;
        }
    }

    public class UpdateChapterCommandHandler : IRequestHandler<UpdateChapterCommand>
    {
        private readonly NeatBookDbContext _context;
        public UpdateChapterCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(UpdateChapterCommand command, CancellationToken cancellationToken)
        {
            var dbChapter = _context.Chapters.FirstOrDefault(a => a.Id == command.Chapter.Id);

            dbChapter.Name = command.Chapter.Name;
            dbChapter.Order = command.Chapter.Order;
            dbChapter.Text = command.Chapter.Text;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
