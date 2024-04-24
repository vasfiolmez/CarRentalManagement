using CarRentalManagement.Application.Interfaces;
using CarRentalManagement.Application.Interfaces.ReservationInterfaces;
using CarRentalManagement.Domain.Entities;
using CarRentalManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRentalManagement.Persistence.Repositories.ReservationRepositories
{
    public class ReservationRepositories : IReservationRepository
    {
       private readonly CarRentalContext _context;

        public ReservationRepositories(CarRentalContext context)
        {
            _context = context;
        }

        public List<Reservation> GetCarsListWithBrands()
        {
            var values = _context.Reservations.Include(c => c.Car).ThenInclude(x=>x.Brand).ToList();
            return values;
        }

        public void ReservationStatusChangeApproved(int id)
        {
          var values=  _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "Onaylandı.";
            _context.SaveChanges();
        }

        public void ReservationStatusChangeCancel(int id)
        {
            var values = _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "İptal Edildi.";
            _context.SaveChanges();
        }

        public void ReservationStatusChangeWait(int id)
        {
            var values = _context.Reservations.Where(x => x.ReservationID == id).FirstOrDefault();
            values.Status = "Müşteri Aranacak.";
            _context.SaveChanges();
        }

    }
}
