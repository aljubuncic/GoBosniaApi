namespace GoTravnikApi.Dto
{
    public class LocationDtoResponse
    {
        public int Id { get; set; }
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }

        public string Address { get; set; }
        public LocationDtoResponse()
        {
            
        }
    }
}
