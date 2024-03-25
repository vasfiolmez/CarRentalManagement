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
    public class CreateCategoryCommandHandler
    {
        private readonly IRepository<BlogCategory> _repository;

        public CreateCategoryCommandHandler(IRepository<BlogCategory> repository)
        {
            _repository = repository;
        }
        public async Task Handle(CreateCategoryCommand command)
        {
            await _repository.CreateAsync(new BlogCategory
            {
                Name = command.Name
            });
        }
    }
}
