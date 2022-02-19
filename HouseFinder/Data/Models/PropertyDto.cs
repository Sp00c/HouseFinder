using System.ComponentModel.DataAnnotations;

namespace HouseFinder.Api.Data.Models
{
    public class PropertyDto
    {
        [Key]
        public int Property_Id { get; set; }
        public string Property_HouseNumber { get; set; }
        public string Property_AddressFirstLine { get; set; }
        public string Property_AddressSecondLine { get; set; }
        public string Property_PostCode { get; set; }
        public string Property_Region { get; set; }
        public string Property_Country { get; set; }
        public string Property_Longitude { get; set; }
        public string Property_Latitude { get; set; }
    }
    
}
