using System.ComponentModel.DataAnnotations;

namespace HouseFinder.Api.Data.Models
{
    public class BlobDto
    {
        [Key]
        public int Blob_Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
