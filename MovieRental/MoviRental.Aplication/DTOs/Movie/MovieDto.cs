using MovieRental.Application.DTOs.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.Movie
{
    public class MovieDto: BaseDto
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
