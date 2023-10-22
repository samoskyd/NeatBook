using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Articles.Queries.GetArticleById
{
    public class GetArticleByIdQuery : IRequest<Article>
    {
        public int Id { get; set; }
        public GetArticleByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetArticleByIdQueryHandler : IRequestHandler<GetArticleByIdQuery, Article>
    {
        private readonly NeatBookDbContext _context;
        public GetArticleByIdQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<Article> Handle(GetArticleByIdQuery request, CancellationToken cancellationToken)
        {
            var article = _context.Articles.FirstOrDefault(u => u.Id == request.Id);

            return Task.FromResult(article);
        }
    }
}
