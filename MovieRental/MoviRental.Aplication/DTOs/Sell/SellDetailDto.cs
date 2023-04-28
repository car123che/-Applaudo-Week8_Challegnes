using MovieRental.Application.DTOs.Movie;
using MovieRental.Application.DTOs.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.Sell
{
    public class SellDetailDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime SellDate { get; set; } = DateTime.Now;
        public string Details { get; set; } = "";
        public virtual MovieDto Movie { get; set; }
        public virtual UserDto User { get; set; }
    }
}
