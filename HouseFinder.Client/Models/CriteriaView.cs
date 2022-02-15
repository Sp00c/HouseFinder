using System.ComponentModel.DataAnnotations;

namespace HouseFinder.Client.Models
{
    public class CriteriaView
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public CriteriaView(string name)
        {
            Name = name;
        }
        public CriteriaView(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
