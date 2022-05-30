using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Domain.DomainServices;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.DomainServicesImpl
{
    public class BookingDomainService : IBookingDomainServices
    {
        private readonly DatabaseContext _db;

        public BookingDomainService(DatabaseContext db)
        {
            _db = db;
        }
        IEnumerable<Domain.Entities.Booking> IBookingDomainServices.GetOtherBookings(Domain.Entities.Booking booking)
        {
            return _db.Bookings.Where(b => b.BookingId != booking.BookingId).ToList();
        }
    }
}
