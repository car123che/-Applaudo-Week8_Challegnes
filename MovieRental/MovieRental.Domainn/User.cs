using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public class User: BaseDomainEntity
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Role { get; set; } = 1;

        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
    }

}
