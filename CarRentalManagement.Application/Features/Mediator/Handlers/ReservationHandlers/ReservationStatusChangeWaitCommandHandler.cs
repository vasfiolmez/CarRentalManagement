using CarRentalManagement.Application.Features.Mediator.Commands.ReservationCommands;
using CarRentalManagement.Application.Interfaces.ReservationInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class ReservationStatusChangeWaitCommandHandler : IRequestHandler<ReservationStatusChangeWaitCommand>
    {
        private readonly IReservationRepository _reservationRepository;

        public ReservationStatusChangeWaitCommandHandler(IReservationRepository reservationRepository)
        {
            _reservationRepository = reservationRepository;
        }

        public async Task Handle(ReservationStatusChangeWaitCommand request, CancellationToken cancellationToken)
        {
            _reservationRepository.ReservationStatusChangeWait(request.Id);
        }
    }
}
