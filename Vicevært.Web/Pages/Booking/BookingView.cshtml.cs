using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Pages.Booking
{
    public class BookingViewModel : PageModel
    {
        private readonly IBookingService _bookingService;

        public BookingViewModel(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [BindProperty] public IEnumerable<BookingIndexModel> Bookings { get; set; } = Enumerable.Empty<BookingIndexModel>();

        public async Task OnGetAsync()
        {
            var booking = new List<BookingIndexModel>();

            var dbBookings = await _bookingService.GetAsync();
            dbBookings.ToList().ForEach(a => booking.Add(new BookingIndexModel(a)));
            Bookings = booking;

        }

        public class BookingIndexModel
        {
            public BookingIndexModel(BookingDto booking)
            {
                BookingId = booking.BookingId;
                Start = booking.Start;
                Slut = booking.Slut;
                LejemålId = booking.LejemålId;
            }

            public int BookingId { get; set; }

            [DisplayName("Start tidspunkt")] public DateTime Start { get; set; }

            [DisplayName("Slut tidspunkt")] public DateTime Slut { get; set; }

            public int LejemålId { get; set; }
        }
    }
}
