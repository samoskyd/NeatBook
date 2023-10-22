using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Commands.DeleteArticle
{
    public class DeleteArticleCommand : IRequest
    {
        public int Id { get; set; }
        public DeleteArticleCommand(int id)
        {
            Id = id;
        }
    }

    public class DeleteArticleCommandHandler : IRequestHandler<DeleteArticleCommand>
    {
        private readonly NeatBookDbContext _context;
        public DeleteArticleCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(DeleteArticleCommand command, CancellationToken cancellationToken)
        {
            var article = _context.Articles.FirstOrDefault(a => a.Id == command.Id);
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
