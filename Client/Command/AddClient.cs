using Client.Context;
using Client.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Command
{
    public class AddClient
    {
        public class Command : IRequest<int>
        {
            public string firstName { get; set; }

            public string LastName { get; set; }

            public string email { get; set; }
        }
        public class CommandHandler : IRequestHandler<Command, int>
        {
            private readonly ClientContext _db;
            public CommandHandler(ClientContext db)
            {
                _db = db;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = new Clients
                {
                    firstName = request.firstName,
                    LastName = request.LastName,
                    email = request.email
                
                };

                await _db.Clients.AddAsync(entity, cancellationToken);
                await _db.SaveChangesAsync(cancellationToken);
                return entity.Id;
                
            }
        }
    }
}
