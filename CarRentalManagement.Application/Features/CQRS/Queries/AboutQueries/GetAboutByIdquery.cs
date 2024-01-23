using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Queries.AboutQueries
{
    public class GetAboutByIdquery
    {
        public GetAboutByIdquery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
