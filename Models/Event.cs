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

        public Event(int id, string name, string description, string type, Location location, string image, DateTime startDate, DateTime endDate)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            Image = image;
            this.startDate = startDate;
            this.endDate = endDate;
        }
        
    }
}
