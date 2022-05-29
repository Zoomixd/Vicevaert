namespace Vicevært.BoligData.Models
{
    public class EjendomModel
    {
        public Guid id { get; set; }

        public string streetName { get; set; }

        public string buildingNumber { get; set; }

        public string postcode { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string countryCode { get; set; }

    }
}
