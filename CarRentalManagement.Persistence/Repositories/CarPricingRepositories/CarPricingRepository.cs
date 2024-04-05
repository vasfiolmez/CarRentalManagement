using CarRentalManagement.Application.Interfaces.CarPricingInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarRentalContext _context;

        public CarPricingRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
           var values=_context.CarPricings.Include(x=>x.Car).ThenInclude(y=>y.Brand).Include(z=>z.Pricing).Where(a=>a.PricingID==2).ToList();
            return values;
        }
    }
}
