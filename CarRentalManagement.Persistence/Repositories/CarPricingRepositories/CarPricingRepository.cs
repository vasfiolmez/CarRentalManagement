using CarRentalManagement.Application.Features.Mediator.Results.CarPricingResults;
using CarRentalManagement.Application.Interfaces.CarPricingInterfaces;
using CarRentalManagement.Application.ViewModel;
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

        public List<CarPricingViewModel> GetCarPricingWithPeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,Name,CoverImageUrl,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([1],[2],[3])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel()
                        {
                            Brand = reader["Name"].ToString(),
                            Model = reader["Model"].ToString(),
                            CoverImageUrl = reader["CoverImageUrl"].ToString(),
                            Amounts = new List<decimal>
                            {
                                Convert.ToDecimal(reader["1"]),
                                Convert.ToDecimal(reader["2"]),
                                Convert.ToDecimal(reader["3"])
                            }
                        };
                        values.Add(carPricingViewModel);
                    }
                }
                _context.Database.CloseConnection();
                return values;
            }
        }

        public List<CarPricing> GetCarPricingWithTimePeriod()
        {
            throw new NotImplementedException();
        }
    }
}
