using CarRentalManagement.Application.Features.Mediator.Queries.ReservationQueries;
using CarRentalManagement.Application.Features.Mediator.Results.ReservationResults;
using CarRentalManagement.Application.Features.Mediator.Results.TestimonialResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.ReservationHandlers
{
    public class GetReservationByIdQueryHandler : IRequestHandler<GetReservationByIdQuery, GetReservationByIdQueryResult>
    {
        private readonly IRepository<Reservation> _repository;

        public GetReservationByIdQueryHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }
        public async Task<GetReservationByIdQueryResult> Handle(GetReservationByIdQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetByIdAsync(request.Id);
            return new GetReservationByIdQueryResult
            {
               Status = value.Status,
               Age = value.Age,
               CarID = value.CarID,
               Description
               = value.Description,
               DriverLicenseYear = value.DriverLicenseYear,
               DropOffLocationID = value.DropOffLocationID,
               Email = value.Email,
               Name = value.Name,
               Phone = value.Phone,
               PickUpLocationID = value.PickUpLocationID,
               Surname = value.Surname,
            };
        }
    }
}
