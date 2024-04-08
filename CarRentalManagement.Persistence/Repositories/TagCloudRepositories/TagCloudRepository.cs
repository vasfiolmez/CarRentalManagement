using CarRentalManagement.Application.Interfaces.TagCloudInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.TagCloudRepositories
{
    public class TagCloudRepository : ITagCloudRepository
    {
        private readonly CarRentalContext _context;

        public TagCloudRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<TagCloud> GetTagCloudsByBlogID(int id)
        {
            var values=_context.TagClouds.Where(x=>x.BlogID==id).ToList();
            return values;
        }
    }
}
