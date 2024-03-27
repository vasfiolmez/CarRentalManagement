using CarRentalManagement.Application.Features.Mediator.Queries.PricingQueries;
using CarRentalManagement.Application.Features.Mediator.Results.PricingResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.PricingHandlers
{
    public class GetPricingByIdQueryHandler : IRequestHandler<GetPricingByIdQuery, GetPricingByIdQueryResult>
    {
        private readonly IRepository<Pricing> _repository;

        public GetPricingByIdQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<GetPricingByIdQueryResult> Handle(GetPricingByIdQuery request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.Id);
            return new GetPricingByIdQueryResult
            {
                Name = values.Name,
                PricingID = values.PricingID
            };
        }
    }
}
