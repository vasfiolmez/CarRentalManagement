using CarRentalManagement.Application.Interfaces.AppUserInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.AppUserRepositories
{
	public class AppUserRepository : IAppUserRepository
	{
		private readonly CarRentalContext _context;

		public AppUserRepository(CarRentalContext context)
		{
			_context = context;
		}	
	}
}
