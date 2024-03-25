using CarRentalManagement.Application.Features.CQRS.Commands.CategoryCommands;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Handlers.BlogCategoryHandlers
{
    public class UpdateCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public UpdateCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task Handle(UpdateCategoryCommand command)
        {
            var values = await _repository.GetByIdAsync(command.BlogCategoryID);
            values.Name = command.Name;
            await _repository.UpdateAsync(values);
        }
    }
}
