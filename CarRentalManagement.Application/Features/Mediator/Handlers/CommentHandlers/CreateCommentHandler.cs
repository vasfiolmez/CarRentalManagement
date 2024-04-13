using CarRentalManagement.Application.Features.Mediator.Commands.CommentCommands;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.CommentHandlers
{
    public class CreateCommentHandler : IRequestHandler<CreateCommentCommand>
    {
        private readonly IRepository<Comment> _commentRepository;

        public CreateCommentHandler(IRepository<Comment> commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public async Task Handle(CreateCommentCommand request, CancellationToken cancellationToken)
        {
            await _commentRepository.CreateAsync(new Comment
            {
                BlogId = request.BlogId,
                CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString()),
                Description = request.Description,
                Email=request.Email,
                Name = request.Name,
            });
        }
    }
}
