using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Client.Models
{
    public class Clients
    {
        [Key]
        public int Id { get; set; }
      
        public string firstName { get; set; }

        public string LastName { get; set; }

        public string email { get; set; }


    }
}
