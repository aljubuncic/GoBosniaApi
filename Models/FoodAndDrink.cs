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

        public FoodAndDrink(int id, string name, string description, string type, Location location, string image, string website, string telephoneNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            Location = location;
            Image = image;
            Website = website;
            TelephoneNumber = telephoneNumber;
        }
    }
}
