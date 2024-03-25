using CarRentalManagement.Application.Features.CQRS.Queries.BrandQueries;
using CarRentalManagement.Application.Features.CQRS.Queries.CategoryQueries;
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
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public GetCategoryByIdQueryHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task<GetCategoryByIdQueryResult> Handle(GetCategoryByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCategoryByIdQueryResult
            { 
                Name = values.Name,
                BlogCategoryID=values.BlogCategoryID
            };
        }
    }
}
