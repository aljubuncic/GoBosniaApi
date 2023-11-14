using GoTravnikApi.Dto;
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
        public List<TouristContent> TouristContents{ get; set; }

        public Subcategory(SubcategoryDto subcategoryDto)
        {
            Id = subcategoryDto.Id;
            Name = subcategoryDto.Name;
        }

        public Subcategory() { }

    }
}

