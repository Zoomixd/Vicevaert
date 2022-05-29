using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Vicevært.BoligData.DataAccess;
using Vicevært.BoligData.Models;

namespace Vicevært.Web.Pages.Ejendom
{
    public class IndexModel : PageModel
    {

        private readonly IBoligData EjendomData;

        public IndexModel(IBoligData ejendomdata)
        {
            EjendomData = ejendomdata;
        }


        

        public List<EjendomModel> data = new List<EjendomModel>();





        public void OnGet()
        {

            data = EjendomData.GetEjendom().Result;
        }

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
