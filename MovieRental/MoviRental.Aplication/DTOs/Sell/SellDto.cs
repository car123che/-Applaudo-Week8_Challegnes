using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.Sell
{
    public class SellDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime SellDate { get; set; } = DateTime.Now;
        public string Details { get; set; } = "";
    }
}
