using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Accommodation : TouristContent
    {
        [ForeignKey("IdRating")]
        public int IdRating { get; set; }
        public Rating Rating { get; set; }
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }

        public Accommodation()
        {
        }

        public Accommodation(int id, string name, string description, string type, int idRating, Rating rating, int idLocation, Location location, string image, string website, string telephoneNumber)
        {
            Id = id;
            Name = name;
            Description = description;
            IdRating = idRating;
            Rating = rating;
            IdLocation = idLocation;
            Location = location;
            Image = image;
            Website = website;
            TelephoneNumber = telephoneNumber;
        }
    }
}
