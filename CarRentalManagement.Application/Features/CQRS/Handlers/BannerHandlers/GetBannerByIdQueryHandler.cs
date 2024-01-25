using CarRentalManagement.Application.Features.CQRS.Queries.AboutQueries;
using CarRentalManagement.Application.Features.CQRS.Queries.BannerQueries;
using CarRentalManagement.Application.Features.CQRS.Results.AboutResults;
using CarRentalManagement.Application.Features.CQRS.Results.BannerResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.BannerHandlers
{
    public class GetBannerByIdQueryHandler
    {
        private readonly IRepository<Banner> _repository;

        public GetBannerByIdQueryHandler(IRepository<Banner> repository)
        {
            _repository = repository;
        }
        public async Task<GetBannerByIdQueryResult> Handle(GetBannerByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetBannerByIdQueryResult
            {
               BannerID=values.BannerID,
               Description=values.Description,
               Title=values.Title,
               VideoDescription=values.VideoDescription,
               VideoUrl=values.VideoUrl
            };
        }

       
    }
}
