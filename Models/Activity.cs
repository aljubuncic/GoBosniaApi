using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Activity : RatedTouristContent
    {
        public Activity()
        {
        }

        public Activity(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, List<Rating> ratings) 
            : base(id, name, description, location, images, subcatgeories, ratings)
        {
        }
    }
}

