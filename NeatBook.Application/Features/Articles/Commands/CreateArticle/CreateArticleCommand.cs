using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Commands.CreateArticle
{
    public class CreateArticleCommand : IRequest
    {
        public Article Article { get; set; }
        public CreateArticleCommand(Article article)
        {
            Article = article;
        }
    }

    public class CreateArticleCommandHandler : IRequestHandler<CreateArticleCommand>
    {
        private readonly NeatBookDbContext _context;
        public CreateArticleCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(CreateArticleCommand command, CancellationToken cancellationToken)
        {
            _context.Articles.Add(command.Article);
            _context.SaveChanges();

            return Unit.Task;
        }
    }
}
