using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Contract.Dtos;

namespace Vicevært.Contract
{
    public interface IBookingService
    {
        Task CreateAsync(BookingDto bookingDto);
        Task<BookingDto?> GetAsync(int id);
        Task<IEnumerable<BookingDto>> GetAsync();
    }
}
