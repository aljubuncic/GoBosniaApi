namespace GoTravnikApi.Dto
{
    public class AccommodationDtoResponse : RatedTouristContentDtoResponse
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public AccommodationDtoResponse()
        {
        }
    }
}
