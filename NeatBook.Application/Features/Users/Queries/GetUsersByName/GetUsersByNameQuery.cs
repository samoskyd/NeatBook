using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Users.Queries.GetUsersByName
{
    public class GetUsersByNameQuery : IRequest<List<User>>
    {
        public string Name { get; set; }
        public GetUsersByNameQuery(string name)
        {
            Name = name;
        }
    }

    public class GetUsersByNameQueryHandler : IRequestHandler<GetUsersByNameQuery, List<User>>
    {
        private readonly NeatBookDbContext _context;
        public GetUsersByNameQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> Handle(GetUsersByNameQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Where(a => a.Name == request.Name).ToList();

            return Task.FromResult(users);
        }
    }
}
