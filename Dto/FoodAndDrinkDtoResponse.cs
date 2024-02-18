namespace GoTravnikApi.Dto
{
    public class FoodAndDrinkDtoResponse : RatedTouristContentDtoResponse
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public FoodAndDrinkDtoResponse() { }
    }
}
