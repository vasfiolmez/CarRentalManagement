using CarRentalManagement.Application.Features.Mediator.Queries.RentACarQueries;
using CarRentalManagement.Application.Features.Mediator.Results.RentACarResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.RentACarInterfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.RentAcarHandlers
{
	public class GetRentACarQueryHandler : IRequestHandler<GetRentACarQuery, List<GetRentACarQueryResult>>
	{

		private readonly IRentACarRepository _repository;

		public GetRentACarQueryHandler(IRentACarRepository repository)
		{
			_repository = repository;
		}

		public async Task<List<GetRentACarQueryResult>> Handle(GetRentACarQuery request, CancellationToken cancellationToken)
		{
			var values =await  _repository.GetByFilterAsync(x=>x.LocationID==request.LocationID&& x.Available==true);
			var results= values.Select(y => new GetRentACarQueryResult
			{
                CarID = y.CarID,
                Brand = y.Car.Brand.Name,
                Model = y.Car.Model,
                CoverImageUrl = y.Car.CoverImageUrl

            }).ToList();
			return results;
		}
	}
}
