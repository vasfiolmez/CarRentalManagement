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
    public class ReservationStatusChangeCancelCommandHandler : IRequestHandler<ReservationStatusChangeCancelCommand>
    {
        private readonly IReservationRepository _repository;

        public ReservationStatusChangeCancelCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }
        public async Task Handle(ReservationStatusChangeCancelCommand request, CancellationToken cancellationToken)
        {
            _repository.ReservationStatusChangeCancel(request.Id);
        }
    }
}
