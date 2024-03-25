using CarRentalManagement.Application.Features.CQRS.Results.BrandResults;
using CarRentalManagement.Application.Features.Mediator.Queries.FeatureQueries;
using CarRentalManagement.Application.Features.Mediator.Results;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.FeatureHandlers;

public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery, List<GetFeatureQueryResult>>
{
    private readonly IRepository<Feature> _repository;

    public GetFeatureQueryHandler(IRepository<Feature> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetFeatureQueryResult>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetAllAsync();
        return values.Select(x => new GetFeatureQueryResult
        {
           FeatureID = x.FeatureID,
           Name= x.Name
        }).ToList();
    }
}
