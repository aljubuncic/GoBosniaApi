using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Event : TouristContent
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public Event()
        {
        }

        public Event(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, DateTime startDate, DateTime endDate) 
            : base(id, name, description, location, images, subcatgeories)
        {
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
