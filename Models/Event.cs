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
        
    }
}
