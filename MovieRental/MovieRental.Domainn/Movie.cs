using MovieRental.Domain.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Domain
{
    public class Movie: BaseDomainEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Poster { get; set; }
        public int Stock { get; set; }
        public string TrailerLink { get; set; }
        public double SalePrice { get; set; }
        public int Likes { get; set; }
        public int Availability { get; set; }
    }
}
