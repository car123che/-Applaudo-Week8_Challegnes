using MovieRental.Application.DTOs.Commom;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.DTOs.Movie
{
    public class MovieDetailDto: BaseDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
