using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.Tag;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.MovieTag
{
    public class MovieTagDto
    {
        public int MovieId { get; set; }
        public int TagId { get; set; }
    }
}
