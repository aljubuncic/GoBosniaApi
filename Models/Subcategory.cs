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

        [ForeignKey("IdTouristContent")]
        public int IdTouristContent {  get; set; }

        public TouristContent TouristContent { get; set; }

        public Subcategory() { }

        public Subcategory(int id, string name, int idTouristContent, TouristContent touristContent)
        {
            Id = id;
            Name = name;
            IdTouristContent = idTouristContent;
            TouristContent = touristContent;
        }
    }
}
