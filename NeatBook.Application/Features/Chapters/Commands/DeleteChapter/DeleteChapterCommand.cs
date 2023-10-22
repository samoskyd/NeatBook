using MediatR;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Commands.DeleteChapter
{
    public class DeleteChapterCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteChapterCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteChapterCommandHandler : IRequestHandler<DeleteChapterCommand>
    {
        private readonly NeatBookDbContext _context;
        public DeleteChapterCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(DeleteChapterCommand command, CancellationToken cancellationToken)
        {
            var chapter = _context.Chapters.FirstOrDefault(a => a.Id == command.Id);
            _context.Chapters.Remove(chapter);
            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
