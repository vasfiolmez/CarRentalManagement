using CarRentalManagement.Application.Features.Mediator.Queries.TagCloudQueries;
using CarRentalManagement.Application.Features.Mediator.Results.TagCloudResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery, GetTagCloudByIdQueryResult>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResult> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var value= await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResult
            {
                BlogID = value.BlogID,
                TagCloudID = value.TagCloudID,
                Name = value.Name
            };
        }
    }
}
