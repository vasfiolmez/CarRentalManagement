using CarRentalManagement.Application.Features.Mediator.Commands.TagCloudCommands;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.TagCloudHandlers
{
    public class CreateTagCloudCommandHandler : IRequestHandler<CreateTagCloudCommand>
    {
        private readonly IRepository<TagCloud> _repository;

        public CreateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateTagCloudCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new TagCloud
            {
                Name = request.Name,
                BlogID = request.BlogID
            });
        }
    }
}
