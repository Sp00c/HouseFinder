using System.ComponentModel.DataAnnotations;

namespace HouseFinder.Api.Data.Models
{
    public class CriteriaDto
    {
        [Key]
        public int Criteria_Id { get; set; }

        public string Criteria_Name { get; set; } 
    }
}
