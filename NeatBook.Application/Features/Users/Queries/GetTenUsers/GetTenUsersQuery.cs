using MediatR;
using NeatBook.Domain.Entities;
using NeatBook.Infrastructure.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeatBook.Application.Features.Users.Queries.GetTenUsers
{
    public class GetTenUsersQuery : IRequest<List<User>>
    {
    }

    public class GetTenUsersQueryHandler : IRequestHandler<GetTenUsersQuery, List<User>>
    {
        private readonly NeatBookDbContext _context;
        public GetTenUsersQueryHandler(NeatBookDbContext context)
        {
            _context = context;
        }

        public Task<List<User>> Handle(GetTenUsersQuery request, CancellationToken cancellationToken)
        {
            var users = _context.Users.Take(10).ToList();

            return Task.FromResult(users);
        }
    }
}
