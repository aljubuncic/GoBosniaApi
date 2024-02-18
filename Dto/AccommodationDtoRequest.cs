namespace GoTravnikApi.Dto
{
    public class AccommodationDtoRequest : RatedTouristContentDtoRequest
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public AccommodationDtoRequest() { }
    }
}
