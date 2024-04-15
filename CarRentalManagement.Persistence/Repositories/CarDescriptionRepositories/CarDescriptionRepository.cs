using CarRentalManagement.Application.Interfaces.CarDescriptionInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.CarDescriptionRepositories
{
	public class CarDescriptionRepository : ICarDescriptionRepository
	{
		private readonly CarRentalContext _context;

		public CarDescriptionRepository(CarRentalContext context)
		{
			_context = context;
		}

		async Task<CarDescription> ICarDescriptionRepository.GetCarDescription(int id)
		{
			var values = _context.CarDescriptions.Where(x => x.CarID == id).FirstOrDefault();
			return values;
		}
	}
}
