using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GoTravnikApi.Models
{
    public class FoodAndDrink : ContactInformationRatedTouristContent
    {
        public FoodAndDrink()
        {
        }

        public FoodAndDrink(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, List<Rating> ratings, string? website, string telephoneNumber) 
            : base(id, name, description, location, images, subcatgeories, ratings, website, telephoneNumber)
        {
        }
    }
}
