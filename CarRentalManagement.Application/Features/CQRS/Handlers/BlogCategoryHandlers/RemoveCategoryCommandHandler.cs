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
    public class RemoveCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public RemoveCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task Handle(RemoveCategoryCommand command)
        {
            var value = await _repository.GetByIdAsync(command.Id);
            await _repository.RemoveAsync(value);
        }
    }
}
