using CarRentalManagement.Application.Features.CQRS.Results.CarResults;
using CarRentalManagement.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarsWithPricingQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetCarsWithPricingQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetCarsWithPricingQueryResult> Handle()
        {
            var values = _repository.GetCarsWithPricings();
            return values.Select(x => new GetCarsWithPricingQueryResult
            {
                BrandID = x.BrandID,
                BrandName = x.Brand.Name,
                BigImageUrl = x.BigImageUrl,
                CarID = x.CarID,
                CoverImageUrl = x.CoverImageUrl,
                Fuel = x.Fuel,
                Km = x.Km,
                Luggage = x.Luggage,
                Model = x.Model,
                Seat = x.Seat,
                Transmission = x.Transmission
            }).ToList();
        }
    }

}
