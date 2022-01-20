using Client.Context;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Client.Command
{
    public class DeleteClient
    {
        public class Command : IRequest
        { 
            public int id { get; set; }
        }

        public class CommandHandler : IRequestHandler<Command, Unit>
        {
            private readonly ClientContext _db;
            public CommandHandler (ClientContext db)
            { _db = db; }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                var client = await _db.Clients.FindAsync(request.id);
                if (client == null)
                {
                    return Unit.Value;
                }
                _db.Clients.Remove(client);
                await _db.SaveChangesAsync(cancellationToken);
                return Unit.Value;
            }
        }
    }
}
