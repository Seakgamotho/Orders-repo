using Client.Context;
using Client.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Query
{
    public class GetClientById
    {
        public class Query : IRequest<Clients>
        {
            public int Id { get; set; }
        }
        public class QueryHandler : IRequestHandler<Query, Clients>
        {
            private readonly ClientContext _db;
            public QueryHandler(ClientContext db)
            {
                _db = db;
            }
            public async Task<Clients> Handle(Query request, CancellationToken cancellationToken)
            {
                return await _db.Clients.FindAsync(request.Id);
            }
        }
    }
}
