using CarRentalManagement.Application.Features.Mediator.Queries.TestimonialQueries;
using CarRentalManagement.Application.Features.Mediator.Results.SocialMediaResults;
using CarRentalManagement.Application.Features.Mediator.Results.TestimonialResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.TestimonialHandlers
{
    public class GetTestimonialQueryHandler : IRequestHandler<GetTestimonialQuery, List<GetTestimonialQueryResult>>
    {
        private readonly IRepository<Testimonial> _repository;

        public GetTestimonialQueryHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTestimonialQueryResult>> Handle(GetTestimonialQuery request, CancellationToken cancellationToken)
        {
            var value = await _repository.GetAllAsync();
            return value.Select(x => new GetTestimonialQueryResult
            {
               Title = x.Title,
               TestimonialID = x.TestimonialID,
               Name = x.Name,
               ImageUrl = x.ImageUrl,
               Comment = x.Comment
            }).ToList();
        }
    }
}
