using System.ComponentModel.DataAnnotations;

namespace HouseFinder.Data
{
    public class CriteriaDto
    {
        [Key]
        public int Criteria_Id { get; set; }

        public string Criteria_Name { get; set; } 
    }
}
