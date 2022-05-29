using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract.Dtos;

namespace Vicevært.Application.Contract
{
    public interface IBookingCommand
    {
        Task CreateAsync(BookingCommandDto bookingDto);
    }
}
