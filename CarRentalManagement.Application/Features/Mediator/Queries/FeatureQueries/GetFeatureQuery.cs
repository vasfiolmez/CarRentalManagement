﻿using CarRentalManagement.Application.Features.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Queries.FeatureQueries
{
    public class GetFeatureQuery:IRequest<List<GetFeatureQueryResult>>
    {
    }
}
