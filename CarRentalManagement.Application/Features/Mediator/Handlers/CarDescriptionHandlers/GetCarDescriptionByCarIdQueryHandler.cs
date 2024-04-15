using CarRentalManagement.Application.Features.Mediator.Queries.CarDescriptionQueries;
using CarRentalManagement.Application.Features.Mediator.Results.CarDescriptionResults;
using CarRentalManagement.Application.Features.Mediator.Results.TestimonialResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.CarDescriptionInterfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.CarDescriptionHandlers
{
	public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery,GetCarDescriptionQueryResult>
	{
		private readonly ICarDescriptionRepository _repository;

		public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository repository)
		{
			_repository = repository;
		}

		public async Task<GetCarDescriptionQueryResult> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
		{
			var value =await  _repository.GetCarDescription(request.Id);
			return new GetCarDescriptionQueryResult
			{
				CarDescriptionID = value.CarDescriptionID,
				CarID = value.CarID,
				Details = value.Details,
			};
		}
	}
}
