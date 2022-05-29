namespace Vicevært.BoligData.Models
{
    public class LejemaalModel
    {
        public Guid LejemålId { get; set; }

        public Guid EjendomId { get; set; }

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
