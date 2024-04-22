﻿using CarRentalManagement.Application.Features.Mediator.Queries.StatisticsQueries;
using CarRentalManagement.Application.Features.Mediator.Results.StatisticsResults;
using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResult>
    {
        private readonly IStatisticsRepository _statisticsRepository;

        public GetAuthorCountQueryHandler(IStatisticsRepository statisticsRepository)
        {
            _statisticsRepository = statisticsRepository;
        }

        public async Task<GetAuthorCountQueryResult> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var value =_statisticsRepository.GetAuthorCount();
            return new GetAuthorCountQueryResult
            {
                AuthorCount = value
            };
        }
    }
}
