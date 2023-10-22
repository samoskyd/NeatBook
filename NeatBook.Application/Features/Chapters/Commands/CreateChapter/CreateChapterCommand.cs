using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Commands.CreateChapter
{
    public class CreateChapterCommand : IRequest
    {
        public Chapter Chapter { get; set; }
        public CreateChapterCommand(Chapter chapter)
        {
            Chapter = chapter;
        }
    }

    public class CreateChapterCommandHandler : IRequestHandler<CreateChapterCommand>
    {
        private readonly NeatBookDbContext _context;
        public CreateChapterCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(CreateChapterCommand command, CancellationToken cancellationToken)
        {
            _context.Chapters.Add(command.Chapter);
            _context.SaveChanges();

            return Unit.Task;
        }
    }
}
