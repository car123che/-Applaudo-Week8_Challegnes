using MediatR;
using MovieRental.Application.DTOs.Rent;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.Rent.Requests.Command
{
    public class ReturnCommand : IRequest<Unit>
    {
        public RentDto RentDto { get; set; }
    }
}
