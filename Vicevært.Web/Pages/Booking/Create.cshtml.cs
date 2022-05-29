using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;

namespace Vicevært.Web.Pages.Booking;

public class CreateModel : PageModel

{
    private readonly IBookingService _bookingService;

    public CreateModel(IBookingService bookingService)
    {
        _bookingService = bookingService;
    }

    [BindProperty] public BookingCreateModel Booking { get; set; } = new();

    public void OnGet()
    {
        Booking = new BookingCreateModel();
    }

    public async Task<IActionResult> OnPostAsync()
    {
        if (!ModelState.IsValid) return Page();

        await _bookingService.CreateAsync(Booking.GetAsBookingDto());
        return RedirectToPage("./Index");
    }

    public class BookingCreateModel
    {
        public int BookingId { get; set; }

        [DisplayName("Start tidspunkt")] public DateTime Start { get; set; } = DateTime.Now;

        [DisplayName("Slut tidspunkt")] public DateTime Slut { get; set; } = DateTime.Now + TimeSpan.FromMinutes(30);

        public int LejemålId { get; set; }

        public BookingDto GetAsBookingDto()
        {
            return new BookingDto
            {
                Start = Start,
                Slut = Slut,
                LejemålId = LejemålId
            };
        }
    }
}

