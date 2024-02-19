namespace GoTravnikApi.Dto.ResponseDto
{
    public class LocationDtoResponse
    {
        public int Id { get; set; }
        public string City { get; set; }
        public string Address { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public LocationDtoResponse()
        {

        }
    }
}
