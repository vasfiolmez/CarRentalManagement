using CarRentalManagement.Application.Features.CQRS.Queries.ContactQueries;
using CarRentalManagement.Application.Features.CQRS.Results.ContactResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactByIdQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactByIdQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }
        public async Task<GetContactByIdQueryResult> Handle(GetContactByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetContactByIdQueryResult
            {
                ContactID = values.ContactID,
                Name = values.Name,
                Email= values.Email,
                Message = values.Message,
                SendDate = values.SendDate,
                Subject = values.Subject
               
            };
        }
    }
}
