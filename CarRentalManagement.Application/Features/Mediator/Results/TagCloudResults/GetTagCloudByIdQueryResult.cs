﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByIdQueryResult
    {
        public int TagCloudID { get; set; }
        public string Name { get; set; }
        public int BlogID { get; set; }
    }
}
