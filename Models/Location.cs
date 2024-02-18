using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Location
    {

        [Key]
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double XCoordinate {  get; set; }
        public double YCoordinate { get; set; }

        public Location()
        {
        }

        public Location(int id, string city, string address, double xCoordinate, double yCoordinate)
        {
            Id = id;
            City = city;
            Address = address;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
        }


    }
}
