using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Exceptions
{
    public class MovieOutOfStockException: Exception
    {
        public MovieOutOfStockException(string message): base(message)
        {
            
        }
    }
}
