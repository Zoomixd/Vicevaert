using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vicevært.Domain.Entities
{
    public class Lejemaal
    {
        [Key]
        public int LejemålId { get; set; }

        //public Guid EjendomId { get; set; }

        public string StreetName { get; set; }

        public string BuildingNumber { get; set; }

        public string SecondaryAddress { get; set; }

        public string Postcode { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string CountryCode { get; set; }

        public bool IsBookable { get; set; }


        //public Lejemaal() { }

        public void CreateBooking()
        {

        }


    }
}
