using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NeatBook.Application.Features.Articles.Queries.GetArticlesByName
{
    public class GetArticlesByNameQuery : IRequest<List<Article>>
    {
        public string Name { get; set; }
        public GetArticlesByNameQuery(string name)
        {
            Name = name;
        }
    }

    public class GetArticlesByNameQueryHandler : IRequestHandler<GetArticlesByNameQuery, List<Article>>
    {
        private readonly NeatBookDbContext _context;
        public GetArticlesByNameQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<Article>> Handle(GetArticlesByNameQuery request, CancellationToken cancellationToken)
        {
            var articles = _context.Articles.Where(a => a.Name == request.Name).ToList();

            return Task.FromResult(articles);
        }
    }
}
