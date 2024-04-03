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
    public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, GetBlogByIdQueryResult>
    {
        private readonly IRepository<Blog> _repository;

        public GetBlogByIdQueryHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogByIdQueryResult> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
        {
            var values=await _repository.GetByIdAsync(request.Id);
            return new GetBlogByIdQueryResult
            {
                AuthorId = values.AuthorId,
                BlogId = values.BlogId,
                BlogCategoryID=values.BlogCategoryID,
                CoverImageUrl = values.CoverImageUrl,
                Title = values.Title,
                CreatedDate = values.CreatedDate
            };

        }
    }
}
