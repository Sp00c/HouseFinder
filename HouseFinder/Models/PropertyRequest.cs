namespace HouseFinder.Api.Models
{
    public class PropertyRequest
    {
        public int Id { get; set; }
        public string HouseNumber { get; set; }
        public string AddressFirstLine { get; set; }
        public string AddressSecondLine { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Longitude { get; set; }
        public string Latitude { get; set; }
    }
}
