using GoTravnikApi.Dto;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Accommodation : ContactInformationRatedTouristContent
    {
        public Accommodation()
        {
        }
        public Accommodation(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, List<Rating> ratings, string? website, string telephoneNumber) 
            : base(id, name, description, location, images, subcatgeories, ratings, website, telephoneNumber)
        {
        }
    }
}
