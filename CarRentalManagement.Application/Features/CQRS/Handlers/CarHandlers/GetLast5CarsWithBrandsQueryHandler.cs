using CarRentalManagement.Application.Features.CQRS.Results.CarResults;
using CarRentalManagement.Application.Interfaces.CarInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetLast5CarsWithBrandsQueryHandler
    {
        private readonly ICarRepository _repository;

        public GetLast5CarsWithBrandsQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }
        public List<GetLast5CarsWithBrandsQueryResult> Handle()
        {
            var values = _repository.GetLast5CarsWithBrands();
            return values.Select(x => new GetLast5CarsWithBrandsQueryResult
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
