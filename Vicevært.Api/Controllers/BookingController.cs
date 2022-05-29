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
        //private readonly IBookingQuery _bookingQuery;

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
    }
}
