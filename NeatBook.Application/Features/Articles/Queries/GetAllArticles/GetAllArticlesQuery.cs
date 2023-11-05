using MediatR;
using NeatBook.Application.Features.Chapters.Queries.GetChaptersByBook;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Queries.GetAllArticles
{
    public class GetAllArticlesQuery : IRequest<List<Article>>
    {
    }

    public class GetAllArticlesQueryHandler : IRequestHandler<GetAllArticlesQuery, List<Article>>
    {
        private readonly NeatBookDbContext _context;
        public GetAllArticlesQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Article>> Handle(GetAllArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = _context.Articles.ToList();

            return Task.FromResult(articles);
        }
    }
}
