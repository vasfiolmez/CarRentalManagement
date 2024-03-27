using CarRentalManagement.Application.Features.Mediator.Queries.SocialMediaQueries;
using CarRentalManagement.Application.Features.Mediator.Results.SocialMediaResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.SocialMediaHandlers;

public class GetSocialMediaQueryHandler : IRequestHandler<GetSocialMediaQuery, List<GetSocialMediaQueryResult>>
{
    private readonly IRepository<SocialMedia> _repository;

    public GetSocialMediaQueryHandler(IRepository<SocialMedia> repository)
    {
        _repository = repository;
    }

    public async Task<List<GetSocialMediaQueryResult>> Handle(GetSocialMediaQuery request, CancellationToken cancellationToken)
    {
        var value = await _repository.GetAllAsync();
        return value.Select(x => new GetSocialMediaQueryResult
        {
            Icon = x.Icon,
            Name = x.Name,
            SocialMediaID = x.SocialMediaID,
            Url=x.Url
        }).ToList();
    }

}
