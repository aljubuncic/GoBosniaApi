using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Post : TouristContent
    {
        public DateTime PostDate { get; set; } = DateTime.Now;

        public Post()
        {
        }

        public Post(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories) 
            : base(id, name, description, location, images, subcatgeories)
        {
        }
    }
}
