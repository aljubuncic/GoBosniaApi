using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace GoTravnikApi.Models
{
    public class FoodAndDrink : TouristContent
    {
        
        
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public FoodAndDrink()
        {
        }

        public FoodAndDrink(int id, string name, string description, string type, int idLocation, Location location, string image, string website, string telephoneNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            IdLocation = idLocation;
            Location = location;
            Image = image;
            Website = website;
            TelephoneNumber = telephoneNumber;
        }
    }
}
