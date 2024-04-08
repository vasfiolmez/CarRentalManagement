using CarRentalManagement.Application.Features.Mediator.Results.BlogResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAuthorByBlogIdQuery:IRequest<List<GetAuthorByBlogIdQueryResult>>
    {
        public int Id { get; set; }

        public GetAuthorByBlogIdQuery(int id)
        {
            Id = id;
        }
    }
}
