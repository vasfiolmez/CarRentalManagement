﻿using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Interfaces.ReviewInterfaces
{
    public interface IReviewRepository
    {
        public List<Review> GetReviewsByCarId(int carid);
    }
}
