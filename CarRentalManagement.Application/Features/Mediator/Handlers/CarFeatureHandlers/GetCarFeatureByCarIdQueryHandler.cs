using CarRentalManagement.Application.Features.Mediator.Queries.CarFeatureQueries;
using CarRentalManagement.Application.Features.Mediator.Results.BlogResults;
using CarRentalManagement.Application.Features.Mediator.Results.CarFeatureResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.CarFeatureInterfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.CarFeatureHandlers
{
    public class GetCarFeatureByCarIdQueryHandler : IRequestHandler<GetCarFeatureByCarIdQuery, List<GetCarFeatureByCarIdQueryResult>>
    {
        private readonly ICarFeatureRepository _carFeatureRepository;

        public GetCarFeatureByCarIdQueryHandler(ICarFeatureRepository carFeatureRepository)
        {
            _carFeatureRepository = carFeatureRepository;
        }

        public async Task<List<GetCarFeatureByCarIdQueryResult>> Handle(GetCarFeatureByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values =_carFeatureRepository.GetCarFeaturesByCarId(request.Id);
            return values.Select(x=> new GetCarFeatureByCarIdQueryResult
            {
                CarFeatureID = x.CarFeatureID,              
                Available=x.Available,
                FeatureName=x.Feature.Name,
                FeatureID=x.FeatureID,
            }).ToList();
            
        }
    }
}
