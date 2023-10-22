using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Chapters.Queries.GetChapterById
{
    public class GetChapterByIdQuery : IRequest<Chapter>
    {
        public int Id { get; set; }
        public GetChapterByIdQuery(int id)
        {
            Id = id;
        }
    }

    public class GetChapterByIdQueryHandler : IRequestHandler<GetChapterByIdQuery, Chapter>
    {
        private readonly NeatBookDbContext _context;
        public GetChapterByIdQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<Chapter> Handle(GetChapterByIdQuery request, CancellationToken cancellationToken)
        {
            var chapter = _context.Chapters.FirstOrDefault(u => u.Id == request.Id);

            return Task.FromResult(chapter);
        }
    }
}
