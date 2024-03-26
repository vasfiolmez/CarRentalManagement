using CarRentalManagement.Application.Features.Mediator.Results.FooterAddressResult;
using CarRentalManagement.Application.Features.Mediator.Results.FooterAdressResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Queries.FooterAddressQueries
{
    public class GetFooterAddressQuery:IRequest<List<GetFooterAdressQueryResult>>
    {

    }
}
