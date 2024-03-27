using CarRentalManagement.Application.Features.Mediator.Queries.LocationQueries;
using CarRentalManagement.Application.Features.Mediator.Results.LocationResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.LocationHandlers;

public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResult>
{
    private readonly IRepository<Location> _repository;

    public GetLocationByIdQueryHandler(IRepository<Location> repository)
    {
        _repository = repository;
    }

    public async Task<GetLocationByIdQueryResult> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
    {
        var values = await _repository.GetByIdAsync(request.Id);
        return new GetLocationByIdQueryResult 
        {
           LocationID= values.LocationID,
           Name=values.Name
        };
    }
}
