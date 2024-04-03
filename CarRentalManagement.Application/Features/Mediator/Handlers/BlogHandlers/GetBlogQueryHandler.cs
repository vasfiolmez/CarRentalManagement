using CarRentalManagement.Application.Features.Mediator.Queries.BlogQueries;
using CarRentalManagement.Application.Features.Mediator.Results.BlogResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<GetBlogQueryResult>>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetBlogQueryResult>> Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetBlogQueryResult
            {
                AuthorId = x.AuthorId,
                BlogCategoryID = x.BlogCategoryID,
                CoverImageUrl = x.CoverImageUrl,
                BlogId = x.BlogId,
                CreatedDate = x.CreatedDate,
                Title = x.Title
            }).ToList();
        }
    }
}
