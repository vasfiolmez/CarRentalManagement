using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.CQRS.Results.CategoryResult
{
    public class GetCategoryByIdQueryResult
    {
        public int BlogCategoryID { get; set; }
        public string Name { get; set; }
    }
}
