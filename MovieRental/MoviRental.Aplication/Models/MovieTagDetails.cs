using MovieRental.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Models
{
    public class MovieTagDetails
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
