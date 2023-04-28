using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRental.Application.Features.Tag.Requests.Command
{
    public class DeleteTagCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
