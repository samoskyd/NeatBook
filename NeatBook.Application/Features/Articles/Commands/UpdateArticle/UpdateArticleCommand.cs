using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Commands.UpdateArticle
{
    public class UpdateArticleCommand : IRequest
    {
        public Article Article { get; set; }
        public UpdateArticleCommand(Article article)
        {
            Article = article;
        }
    }

    public class UpdateArticleCommandHandler : IRequestHandler<UpdateArticleCommand>
    {
        private readonly NeatBookDbContext _context;
        public UpdateArticleCommandHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task Handle(UpdateArticleCommand command, CancellationToken cancellationToken)
        {
            var dbArticle = _context.Articles.FirstOrDefault(a => a.Id == command.Article.Id);

            dbArticle.ArticleGenre = command.Article.ArticleGenre;
            dbArticle.Language = command.Article.Language;
            dbArticle.AgeRestrictions = command.Article.AgeRestrictions;
            dbArticle.AuthorRights = command.Article.AuthorRights;
            dbArticle.Name = command.Article.Name;
            dbArticle.Text = command.Article.Text;

            _context.SaveChanges();
            return Unit.Task;
        }
    }
}
