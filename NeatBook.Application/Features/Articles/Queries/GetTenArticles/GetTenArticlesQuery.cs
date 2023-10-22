using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Queries.GetTenArticles
{
    public class GetTenArticlesQuery : IRequest<List<Article>>
    {
    }

    public class GetTenArticlesQueryHandler : IRequestHandler<GetTenArticlesQuery, List<Article>>
    {
        private readonly NeatBookDbContext _context;
        public GetTenArticlesQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Article>> Handle(GetTenArticlesQuery request, CancellationToken cancellationToken)
        {
            var articles = _context.Articles.Take(10).ToList();

            return Task.FromResult(articles);
        }
    }
}
