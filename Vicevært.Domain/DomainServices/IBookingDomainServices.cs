using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.DomainServices
{
    public interface IBookingDomainServices
    {
        IEnumerable<Entities.Booking> GetOtherBookings(Domain.Entities.Booking booking);
    }
}
