using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Infrastructure;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.RepositoriesImpl
{
    public class BookingRepository : IBookingRepository
    {

        private readonly DatabaseContext _db;

        public BookingRepository(DatabaseContext db)
        {
            _db = db;
        }

        async Task IBookingRepository.AddAsync(Domain.Entities.Booking booking)
        {
            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();
        }

    }
}
