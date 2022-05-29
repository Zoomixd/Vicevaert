using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vicevært.BoligData.DataAccess;
using Vicevært.BoligData.Models;
using Vicevært.Infrastructure.RepositoriesImpl;
using Vicevært.Domain.Entities;
using Vicevært.Infrastructure.Database;
using Vicevært.Contract;
using Vicevært.Contract.Dtos;
using System.ComponentModel;


namespace Vicevært.Web.Pages.Booking
{
    public class IndexModel : PageModel
    {
        private readonly ILejemaalService _lejemaalService;

        public IndexModel(ILejemaalService lejemaalService)
        {
            _lejemaalService = lejemaalService;
        }



        [BindProperty] public IEnumerable<AvailableLejemaalModel> Lejemaal { get; set; } = Enumerable.Empty<AvailableLejemaalModel>();

        public async Task OnGetAsync()
        {
            var lejemaal = new List<AvailableLejemaalModel>();
            var dbLejemaal = await _lejemaalService.GetAsync();
            dbLejemaal.ToList().ForEach(a => lejemaal.Add(new AvailableLejemaalModel(a)));
            Lejemaal = lejemaal;

        }



        public class AvailableLejemaalModel
        {
            public AvailableLejemaalModel(LejemaalDto lejemaal)
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


}