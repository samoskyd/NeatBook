using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Commands.PublishArticle
{
    public class PublishArticleCommand : IRequest
    {
        public Article Article { get; set; }
        public PublishArticleCommand(Article article)
        {
            Article = article;
        }
    }

    public class PublishArticleCommandHandler : IRequestHandler<PublishArticleCommand>
    {
        private readonly NeatBookDbContext _context;
        public PublishArticleCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(PublishArticleCommand command, CancellationToken cancellationToken)
        {
            var dbArticle = _context.Articles.FirstOrDefault(a => a.Id == command.Article.Id);

            bool published = command.Article.Published;
            dbArticle.Published = published;

            if (published) dbArticle.PublishingDate = DateTime.UtcNow;
            else dbArticle.PublishingDate = null;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
