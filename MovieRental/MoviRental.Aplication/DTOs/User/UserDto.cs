using MovieRental.Application.DTOs.Commom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.DTOs.User
{
    public class UserDto: BaseDto
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Role { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; } 
    }
}
