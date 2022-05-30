using Microsoft.AspNetCore.Mvc;
using Vicevært.Application.Contract;
using Vicevært.Application.Contract.Dtos;
using Vicevært.Contract.Dtos;

namespace Vicevært.Api.Controllers
{
    [Route("api/Booking")]
    [ApiController]
    public class BookingController : ControllerBase //, IBookingService
    {
        private readonly IBookingCommand _bookingCommand;
        private readonly IBookingQuery _bookingQuery;

        public BookingController(IBookingCommand bookingCommand)
        {

            _bookingCommand = bookingCommand;
        }

        // POST api/<BookingController>
        [HttpPost]
        public async Task<ActionResult> CreateAsync([FromBody] BookingDto value)
        {
            await _bookingCommand.CreateAsync(new BookingCommandDto
            { BookingId = value.BookingId, Slut = value.Slut, Start = value.Start, LejemålId = value.LejemålId });
            return Ok();
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingDto>>> GetAsync()
        {
            var result = new List<BookingDto>();
            var bookings = await _bookingQuery.GetBookingsAsync();
            bookings.ToList()
                .ForEach(a => result.Add(new BookingDto { BookingId = a.BookingId, Slut = a.Slut, Start = a.Start, LejemålId = a.LejemålId }));
            return result;
        }

        // GET api/<BookingController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BookingDto?>> GetAsync(int id)
        {
            var booking = await _bookingQuery.GetBookingAsync(id);
            if (booking is null) return BadRequest();
            return new BookingDto { BookingId = booking.BookingId, Slut = booking.Slut, Start = booking.Start, LejemålId = booking.LejemålId };
        }
    }
}
