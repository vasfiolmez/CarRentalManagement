using CarRentalManagement.Application.Features.Mediator.Commands.PricingCommands;
using CarRentalManagement.Application.Features.Mediator.Commands.ReservationCommands;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.ReservationInterfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class ReservationStatusChangeApprovedCommandHandler : IRequestHandler<ReservationStatusChangeApprovedCommand>
    {
        private readonly IReservationRepository _repository;

        public ReservationStatusChangeApprovedCommandHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(ReservationStatusChangeApprovedCommand request, CancellationToken cancellationToken)
        {
            _repository.ReservationStatusChangeApproved(request.Id);
        }
    }
}
