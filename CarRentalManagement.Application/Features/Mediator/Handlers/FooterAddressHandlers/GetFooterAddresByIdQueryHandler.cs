using CarRentalManagement.Application.Features.Mediator.Queries.FooterAddressQueries;
using CarRentalManagement.Application.Features.Mediator.Results.FooterAddressResult;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.FooterAddressHandlers
{
    public class GetFooterAddresByIdQueryHandler : IRequestHandler<GetFooterAddressByIdQuery, GetFooterAddressByIdQueryResult>
    {
        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddresByIdQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<GetFooterAddressByIdQueryResult> Handle(GetFooterAddressByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFooterAddressByIdQueryResult
            {
                FooterAddressID=values.FooterAddressID,
                Address = values.Address,
                Description = values.Description,
                Email = values.Email,
                Phone = values.Phone
            };
        }
    }
}
