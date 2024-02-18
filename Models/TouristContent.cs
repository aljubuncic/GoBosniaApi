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
        public List<Image> Images { get; set; }
        public List<Subcategory> Subcategories{ get; set; }
        public TouristContent()
        {
        }

        public TouristContent(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            Images = images;
            Subcategories = subcatgeories;
        }
    }
}


