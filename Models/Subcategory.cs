using GoTravnikApi.Dto;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Subcategory
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public List<TouristContent> TouristContents{ get; set; }

        public Subcategory() { }

        public Subcategory(int id, string name, List<TouristContent> touristContents)
        {
            Id = id;
            Name = name;
            TouristContents = touristContents;
        }

    }
}

