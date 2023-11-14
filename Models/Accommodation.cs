using GoTravnikApi.Dto;
using Microsoft.CodeAnalysis;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoTravnikApi.Models
{
    public class Accommodation : TouristContent
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }

        public List<Subcategory> SubCategoryList { get; set; } = null;

        public Accommodation()
        {
        }

        public Accommodation(AccommodationDto accommodationDto)
        {
            Id = accommodationDto.Id;
            Name = accommodationDto.Name;
            Description = accommodationDto.Description;
            Location = accommodationDto.Location;
            Image = accommodationDto.Image;
            Website = accommodationDto.Website;
            TelephoneNumber = accommodationDto.TelephoneNumber;
            Ratings = accommodationDto.Ratings;
        }

        public Accommodation(int id, string name, string description, string type, int idRating, Rating rating, Location location, string image, string website, string telephoneNumber)
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
