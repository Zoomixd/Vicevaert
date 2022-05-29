using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Application.Infrastructure;
using Vicevært.Domain.Entities;

namespace Vicevært.Application.Implementation
{
    public class BookingCommand : IBookingCommand
    {
        private readonly IBookingRepository _repository;

        public BookingCommand(IBookingRepository repository)
        {

            _repository = repository;
        }


        async Task IBookingCommand.CreateAsync(BookingCommandDto bookingDto)
        {
            var booking = new Vicevært.Domain.Entities.Booking(bookingDto.Start, bookingDto.Slut, bookingDto.LejemålId);
            await _repository.AddAsync(booking);
        }
    }
}
