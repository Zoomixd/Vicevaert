using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Application.Infrastructure
{
    public interface IBookingRepository
    {
        Task AddAsync(Domain.Entities.Booking booking);
        Task<Domain.Entities.Booking> GetAsync(int id);
    }
}
