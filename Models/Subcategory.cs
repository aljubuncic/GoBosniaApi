using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }

        [ForeignKey("TouristContent")]
        public int IdTouristContent {  get; set; }

        public TouristContent TouristContent { get; set; }
    }
}
