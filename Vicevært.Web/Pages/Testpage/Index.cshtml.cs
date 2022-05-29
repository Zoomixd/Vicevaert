using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vicevært.BoligData.DataAccess;
using Vicevært.BoligData.Models;

namespace Vicevært.Web.Pages.Testpage
{
    public class IndexModel : PageModel
    {
        private readonly IBoligData EjendomData;

        public IndexModel(IBoligData ejendomdata)
        {
            EjendomData = ejendomdata;
        }
        public List<LejemaalModel> maal { get; set; } = new();
        public List<LejemaalModel> maale;
        public List<EjendomModel> data = new List<EjendomModel>();
        public List<LejemaalModel> lejemaal { get; set; } = new();

        public void OnGet()
        {

            data = EjendomData.GetEjendom().Result;

            foreach (var item in data)
            {


                maal = EjendomData.ListLejemaalOnEjendom(item.id).Result;

            }



        }


        //public void Verdi() {
        //    data = EjendomData.GetEjendom().Result;

        //    foreach (var item in data)
        //    {
        //        EjendomData.ListLejemaalOnEjendom(item.id);

        //    }

        //}
         
        public class EjendomCreateModel
        {
            public Guid id { get; set; }

            public string streetName { get; set; }

            public int buildingNumber { get; set; }

            public int postcode { get; set; }

            public string city { get; set; }

            public string state { get; set; }

            public string countryCode { get; set; }

            public EjendomCreateModel()
            {

            }
        }
    }
}
