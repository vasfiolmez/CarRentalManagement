using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Commands.ReservationCommands
{
    public class ReservationStatusChangeApprovedCommand:IRequest
    {
        public int Id { get; set; }

        public ReservationStatusChangeApprovedCommand(int id)
        {
            Id = id;
        }
    }
}
