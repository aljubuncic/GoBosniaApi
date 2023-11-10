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

        [ForeignKey("IdLocation")]
        public int IdLocation { get; set; }

        public Location Location { get; set; }
        public string Image { get; set; }
    }
}
