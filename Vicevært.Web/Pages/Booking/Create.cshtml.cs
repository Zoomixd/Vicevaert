using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;
using static Vicevært.Web.Pages.Lejemaal.IndexModel;

namespace Vicevært.Web.Pages.Booking;

public class CreateModel : PageModel
{ 


    private readonly IBookingService _bookingService;
    private readonly ILejemaalService _lejemaalService;

public CreateModel(IBookingService bookingService, ILejemaalService lejemaalService)
    {
        _bookingService = bookingService;
        _lejemaalService = lejemaalService;
    }

    [BindProperty] public IEnumerable<LejemaalIndexModel> Lejemaal { get; set; } = Enumerable.Empty<LejemaalIndexModel>();

    [BindProperty] public BookingCreateModel Booking { get; set; } = new();

    public async Task OnGetAsync(int lejemålid)
    {
        Booking = new BookingCreateModel();
        var lejemaal = new List<LejemaalIndexModel>();
        var dbLejemaal = await _lejemaalService.GetAsync();
        dbLejemaal.ToList().ForEach(a => lejemaal.Add(new LejemaalIndexModel(a)));
        Lejemaal = lejemaal;
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

    public class LejemaalIndexModel
    {
        public LejemaalIndexModel(LejemaalDto lejemaal)
        {
            LejemålId = lejemaal.LejemålId;
            StreetName = lejemaal.StreetName;
            BuildingNumber = lejemaal.BuildingNumber;
            SecondaryAddress = lejemaal.SecondaryAddress;
            Postcode = lejemaal.Postcode;
            City = lejemaal.City;
            State = lejemaal.State;
            CountryCode = lejemaal.CountryCode;
            IsBookable = lejemaal.IsBookable;
        }

        [DisplayName("Lejemål ID")] public int LejemålId { get; set; }

        //public Guid EjendomId { get; set; }

        public string StreetName { get; set; }

        public string BuildingNumber { get; set; }

        public string SecondaryAddress { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public bool IsBookable { get; set; }
    }
}

