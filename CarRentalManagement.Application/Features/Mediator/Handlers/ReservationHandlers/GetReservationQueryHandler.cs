using CarRentalManagement.Application.Features.Mediator.Queries.ReservationQueries;
using CarRentalManagement.Application.Features.Mediator.Results.ReservationResults;
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
    public class GetReservationQueryHandler:IRequestHandler<GetReservationQuery, List<GetReservationQueryResult>>
    {
        private readonly IReservationRepository _repository;

        public GetReservationQueryHandler(IReservationRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReservationQueryResult>> Handle(GetReservationQuery request, CancellationToken cancellationToken)
    {
        var value =  _repository.GetCarsListWithBrands();
        return value.Select(x => new GetReservationQueryResult
        {
            Surname=x.Surname,
            Name=x.Name,
            Age=x.Age,
            Description=x.Description,
            BrandName=x.Car.Brand.Name,
            CarModel=x.Car.Model,
            Status=x.Status,
            Email=x.Email,
            Phone = x.Phone,
            DriverLicenseYear = x.DriverLicenseYear,
            CarID=x.CarID,
            DropOffLocationID=x.DropOffLocationID,
            PickUpLocationID=x.PickUpLocationID,
            ReservationID=x.ReservationID                  
        }).ToList();
    }

}
}
