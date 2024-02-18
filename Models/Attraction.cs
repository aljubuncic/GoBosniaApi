using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Attraction : TouristContent
    {
        public Attraction()
        {
        }

        public Attraction(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories) 
            : base(id, name, description, location, images, subcatgeories)
        {
        }
    }
}
