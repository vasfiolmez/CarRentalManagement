using CarRentalManagement.Application.Features.Mediator.Queries.CarPricingQueries;
using CarRentalManagement.Application.Features.Mediator.Results.CarPricingResults;
using CarRentalManagement.Application.Interfaces.CarPricingInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.CarPricingHandlers
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery, List<GetCarPricingWithCarQueryResult>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResult>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {
            var values = _carPricingRepository.GetCarPricingWithCars();
            return values.Select(x=> new GetCarPricingWithCarQueryResult
            {
                CarPricingId=x.CarPricingID,
                Amount=x.Amount,
                Brand=x.Car.Brand.Name,
                CoverImageUrl=x.Car.CoverImageUrl,
                Model=x.Car.Model
            }).ToList();
        }
    }
}
