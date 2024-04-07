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
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery, List<GetTagCloudQueryResult>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResult>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x=>new GetTagCloudQueryResult
            {
                BlogID = x.BlogID,
                Name = x.Name,
                TagCloudID = x.TagCloudID,
            }).ToList();
        }
    }
}
