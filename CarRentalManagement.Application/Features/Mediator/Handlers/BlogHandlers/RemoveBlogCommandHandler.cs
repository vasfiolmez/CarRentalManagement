using CarRentalManagement.Application.Features.Mediator.Commands.BlogCommands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.BlogHandlers
{
    public class RemoveBlogCommandHandler:IRequest<RemoveBlogCommand>
    {
        public int Id { get; set; }

        public RemoveBlogCommandHandler(int id)
        {
            Id = id;
        }
    }
}
