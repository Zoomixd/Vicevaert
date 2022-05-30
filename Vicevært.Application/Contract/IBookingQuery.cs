using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract.Dtos;

namespace Vicevært.Application.Contract
{
    public interface IBookingQuery
    {
        Task<BookingQueryDto?> GetBookingAsync(int id);
        Task<IEnumerable<BookingQueryDto>> GetBookingsAsync();
    }
}
