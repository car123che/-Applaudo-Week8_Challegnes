using MediatR;
using MovieRental.Application.DTOs.Sell;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieRental.Application.Features.Sell.Requests.Command
{
    public class SellCommand : IRequest<int>
    {
        public SellDto SellDto { get; set; }
    }
}
