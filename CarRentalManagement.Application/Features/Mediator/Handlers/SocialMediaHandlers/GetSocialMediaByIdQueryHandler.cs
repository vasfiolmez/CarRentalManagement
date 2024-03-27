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

namespace CarRentalManagement.Application.Features.Mediator.Handlers.SocialMediaHandlers
{
    public class GetSocialMediaByIdQueryHandler : IRequestHandler<GetSocialMediaByIdQuery, GetSocialMediaByIdQueryResult>
    {
        private readonly IRepository<SocialMedia> _repository;

        public GetSocialMediaByIdQueryHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task<GetSocialMediaByIdQueryResult> Handle(GetSocialMediaByIdQuery request, CancellationToken cancellationToken)
        {
            var value=await _repository.GetByIdAsync(request.Id);
            return new GetSocialMediaByIdQueryResult
            {
                Icon = value.Icon,
                Name = value.Name,
                SocialMediaID = value.SocialMediaID,
                Url = value.Url
            };
        }
    }
}
