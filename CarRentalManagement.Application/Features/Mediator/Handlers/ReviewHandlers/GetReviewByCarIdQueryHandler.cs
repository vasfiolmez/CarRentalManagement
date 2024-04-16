using CarRentalManagement.Application.Features.Mediator.Queries.ReviewQueries;
using CarRentalManagement.Application.Features.Mediator.Results.ReviewResults;
using CarRentalManagement.Application.Interfaces.ReviewInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.ReviewHandlers
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<GetReviewByCarIdQuery, List<GetReviewByCarIdQueryResult>>
    {
        private readonly IReviewRepository _repository;

        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResult>> Handle(GetReviewByCarIdQuery request, CancellationToken cancellationToken)
        {
            var value =  _repository.GetReviewsByCarId(request.Id);
            return value.Select(x=>new GetReviewByCarIdQueryResult
            {
                CarID = x.CarID,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RatingValue = x.RatingValue,
                ReviewDate = x.ReviewDate,
                ReviewId=request.Id
            }).ToList();

        }
    }
}
