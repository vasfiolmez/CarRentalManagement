﻿using CarRentalManagement.Application.Interfaces.RentACarInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.RentACarRepository
{
	public class RentACarRepository : IRentACarRepository
	{
		private readonly CarRentalContext _context;

		public RentACarRepository(CarRentalContext context)
		{
			_context = context;
		}

		public async Task< List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
		{
			var values=await _context.RentACars.Where(filter).Include(x=>x.Car).ThenInclude(y=>y.Brand).ToListAsync();
			return values;
		}
	}
}
