﻿using CarRentalManagement.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRentalManagement.Application.Features.Mediator.Results.StatisticsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetBrandCountQueryHandler : IRequestHandler<GetBrandCountQuery, GetBrandCountQueryResult>
    {
        public Task<GetBrandCountQueryResult> Handle(GetBrandCountQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
