using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Event : TouristContent
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public Event()
        {
        }

        public Event(int id, string name, string description, string type, int idLocation, Location location, string image, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            IdLocation = idLocation;
            Location = location;
            Image = image;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        
    }
}
