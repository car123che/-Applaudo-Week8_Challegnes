using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public class Sell: BaseDomainEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime SellDate { get; set; }
        public string Details { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
