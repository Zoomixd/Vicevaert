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

namespace Vicevært.Web.Pages.Lejemaal
{
    public class IndexModel : PageModel
    {
        private readonly ILejemaalService _lejemaalService;

        public IndexModel(ILejemaalService lejemaalService)
        {
            _lejemaalService = lejemaalService;
        }



        [BindProperty] public IEnumerable<LejemaalIndexModel> Lejemaal { get; set; } = Enumerable.Empty<LejemaalIndexModel>();

        public async Task OnGetAsync()
        {
            var lejemaal = new List<LejemaalIndexModel>();
            var dbLejemaal = await _lejemaalService.GetAsync();
            dbLejemaal.ToList().ForEach(a => lejemaal.Add(new LejemaalIndexModel(a)));
            Lejemaal = lejemaal;

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
















        //private readonly IBoligData EjendomData;

        //public IndexModel(IBoligData ejendomdata)
        //{
        //    EjendomData = ejendomdata;
        //}

        //public List<LejemaalModel> maal;

        //public List<LejemaalModel> lejemaal { get; set; } = new();

        //[BindProperty] public LejerCreateModel Lejemaal { get; set; } = new();




        //public void OnGet()
        //{


        //    //var id = Guid.Parse(781f03f7-4c43-4e15-98de-54186ca69c83);
        //    //maal = EjendomData.ListLejemaalOnEjendom(id).Result;
        //    //foreach (LejemaalModel item in maal)
        //    //{
        //    //    if (/*item.IsBookable == true*/true)
        //    //    {



        //    //        lejemaal.Add(item);
        //    //    }
        //    //}
        //}

        //public void OnPostEjendomsøg(string Ejendomid)
        //{

        //    var id = Guid.Parse(Ejendomid);
        //    maal = EjendomData.ListLejemaalOnEjendom(id).Result;



        //}

        //public void OnPostLejemålsøg(Guid Lejemålid)
        //{

        //    maal = EjendomData.ListLejemaalOnEjendom(Lejemålid).Result;



        //}

        //public class LejerCreateModel
        //{
        //    public string StreetName { get; set; }

        //    public string BuildingNumber { get; set; }

        //    public Guid Lejemålid { get; set; }
        //    public Guid Ejendomid { get; set; }

        //    public LejerCreateModel()
        //    {

        //    }

        //    public LejerCreateModel getAsEjendomId() 
        //    { 
        //        return new LejerCreateModel {Ejendomid = Ejendomid };
        //    }
        //}
    }
}
