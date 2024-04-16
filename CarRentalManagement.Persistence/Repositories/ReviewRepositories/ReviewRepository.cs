using CarRentalManagement.Application.Interfaces.ReviewInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.ReviewRepositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly CarRentalContext _context;

        public ReviewRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByCarId(int carid)
        {
            var values=_context.Reviews.Where(x=>x.CarID==carid).ToList();
            return values;
        }
    }
}
