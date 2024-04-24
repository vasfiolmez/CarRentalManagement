using CarRentalManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Application.Interfaces.ReservationInterfaces
{
    public interface IReservationRepository
    {
        void ReservationStatusChangeApproved(int id);
        void ReservationStatusChangeCancel(int id);
        void ReservationStatusChangeWait(int id);
        List<Reservation> GetCarsListWithBrands();
    }
}
