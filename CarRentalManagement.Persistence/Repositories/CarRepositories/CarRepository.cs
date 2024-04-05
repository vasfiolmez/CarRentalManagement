using CarRentalManagement.Application.Interfaces.CarInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {
        private readonly CarRentalContext _context;

        public CarRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values=_context.Cars.Include(c => c.Brand).ToList();
            return values;
        }


        public List<Car> GetLast5CarsWithBrands()
        {
            var values= _context.Cars.Include(x=>x.Brand).OrderByDescending(x=>x.CarID).Take(5).ToList();
            return values;
        }
    }
}
