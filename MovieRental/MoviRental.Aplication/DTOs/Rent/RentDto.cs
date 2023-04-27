using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.Rent
{
    public class RentDto
    {
        public int MovieId { get; set; }
        public int UserId { get; set; }
        public DateTime rentedDate { get; set; } = DateTime.Now;
        public string returnDate { get; set; } = DateTime.Now.AddMonths(1).ToString();
        public string Comments { get; set; } = "";
    }
}
