namespace GoTravnikApi.Dto
{
    public class AccommodationDtoRequest : TouristContentDtoRequest
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public AccommodationDtoRequest() { }
    }
}
