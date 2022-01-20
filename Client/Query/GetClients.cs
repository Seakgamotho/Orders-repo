using Client.Context;
using Client.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
    public class GetClients
    {
        public class Query : IRequest<IEnumerable<Clients>>
        { }

        public class GetClientHandler : IRequestHandler<Query, IEnumerable<Clients>>
        {
            private readonly ClientContext _db;
            public GetClientHandler(ClientContext db)
            {
                _db = db;
            }

            public async Task<IEnumerable<Clients>> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Clients.ToListAsync(cancellationToken);
            }

         
        }
    }
}
