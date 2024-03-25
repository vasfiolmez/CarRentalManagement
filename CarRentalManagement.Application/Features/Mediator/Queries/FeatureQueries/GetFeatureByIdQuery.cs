﻿using CarRentalManagement.Application.Features.Mediator.Results;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Queries.FeatureQueries;

public class GetFeatureByIdQuery:IRequest<GetFeatureByIdQueryResult>
{
    public int Id { get; set; }

    public GetFeatureByIdQuery(int id)
    {
        Id = id;
    }
}
