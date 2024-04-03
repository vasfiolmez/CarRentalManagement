using CarRentalManagement.Application.Features.Mediator.Commands.BlogCommands;
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
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand>
    {
        private readonly IRepository<Blog> _repository;

        public CreateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
             await _repository.CreateAsync(new Blog
             {
                 CoverImageUrl = request.CoverImageUrl,
                 CreatedDate = request.CreatedDate,
                 Title = request.Title,
                 BlogCategoryID = request.BlogCategoryID,
                 AuthorId=request.AuthorId
             });
        }
    }
}
