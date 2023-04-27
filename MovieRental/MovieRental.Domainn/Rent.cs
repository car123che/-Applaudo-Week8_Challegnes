using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public class Rent: BaseDomainEntity
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime rentedDate { get; set; }
        public string returnDate { get; set; }
        public string Comments { get; set; }
        public virtual Movie Movie { get; set; }
        public virtual User User { get; set; }
    }
}
