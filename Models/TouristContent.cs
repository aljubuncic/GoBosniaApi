using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public abstract class TouristContent
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Location Location { get; set; }
        public string Image { get; set; }
        public List<Subcategory> Subcategories { get; set; }
        public List<Rating> Ratings { get; set; }
    }
}
