namespace GoTravnikApi.Dto
{
    public class LocationDtoRequest
    {
        public double XCoordinate { get; set; }
        public double YCoordinate { get; set; }
        public string Address { get; set; }

        public LocationDtoRequest()
        {
            
        }
    }
}
