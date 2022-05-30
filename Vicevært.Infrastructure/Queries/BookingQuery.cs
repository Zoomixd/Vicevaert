using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Infrastructure.Database;

namespace Vicevært.Infrastructure.Queries
{
    public class BookingQuery : IBookingQuery
    {
        private readonly DatabaseContext _db;

        public BookingQuery(DatabaseContext db)
        {
            _db = db;
        }

        async Task<BookingQueryDto?> IBookingQuery.GetBookingAsync(int id)
        {
            var result = await _db.Bookings.FindAsync(id);
            if (result is null) return new BookingQueryDto();

            return new BookingQueryDto
            {
                BookingId = result.BookingId,
                Start = result.Start,
                Slut = result.Slut,
                LejemålId = result.LejemålId
            };
        }

        async Task<IEnumerable<BookingQueryDto>> IBookingQuery.GetBookingsAsync()
        {
            var result = new List<BookingQueryDto>();
            var dbBookings = await _db.Bookings.ToListAsync();
            dbBookings.ForEach(a => result.Add(new BookingQueryDto
            {
                BookingId = a.BookingId,
                Start = a.Start,
                Slut = a.Slut,
                LejemålId = a.LejemålId
            }));
            return result;
        }




    }
}