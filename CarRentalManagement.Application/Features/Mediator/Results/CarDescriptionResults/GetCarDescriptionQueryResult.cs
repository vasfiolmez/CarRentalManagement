﻿using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Features.Mediator.Results.CarDescriptionResults
{
	public class GetCarDescriptionQueryResult
	{
		public int CarDescriptionID { get; set; }
		public int CarID { get; set; }
		public string Details { get; set; }
	}
}
