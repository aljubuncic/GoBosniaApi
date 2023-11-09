using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class Location
    {

        [Key]
        public int Id { get; set; }
        public double XCoordinate {  get; set; }
        public double YCoordinate { get; set; }

        public string Address { get; set; }

        public Location()
        {
        }

        public Location(int id, double xCoordinate, double yCoordinate, string address)
        {
            Id = id;
            XCoordinate = xCoordinate;
            YCoordinate = yCoordinate;
            Address = address;
        }


    }
}
