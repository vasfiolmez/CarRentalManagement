using CarRentalManagement.Application.Interfaces.CarFeatureInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarRentalContext _context;

        public CarFeatureRepository(CarRentalContext context)
        {
            _context = context;
        }

        public List<CarFeature> GetCarFeaturesByCarId(int carId)
        {
           var values=_context.CarFeatures.Include(y=>y.Feature).Where(x=>x.CarID==carId).ToList();
            return values;
        }
        public void ChangeCarFeatureAvailableToFalse(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public async void ChangeCarFeatureAvailableToTrue(int id)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == id).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();
        }
    }
}
