namespace GoTravnikApi.Dto
{
    public class FoodAndDrinkDtoRequest : RatedTouristContentDtoRequest
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public FoodAndDrinkDtoRequest() { }
    }
}
