using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public class Tag: BaseDomainEntity
    {
        public string Name { get; set; }
    }
}
