using CarRentalManagement.Application.Features.CQRS.Results.BrandResults;
using CarRentalManagement.Application.Features.CQRS.Results.CategoryResult;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.BlogCategoryHandlers
{
    public class GetCategoryQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetCategoryQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task<List<GetCategoryQueryResult>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetCategoryQueryResult
            {             
                Name = x.Name,
                BlogCategoryID=x.BlogCategoryID
                
            }).ToList();
        }
    }
}
