using Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Interface
{
    interface IClient
    {
        Task<IEnumerable<Clients>> Get(); 
        Task<Clients> Get(int id); 
        Task<Clients> Create(Clients clients); 
        Task update(Clients client); 
        Task Dalete(int id); 
    }
}
