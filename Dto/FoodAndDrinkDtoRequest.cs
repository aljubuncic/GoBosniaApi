namespace GoTravnikApi.Dto
{
    public class FoodAndDrinkDtoRequest : TouristContentDtoRequest
    {
        public string Website { get; set; }
        public string TelephoneNumber { get; set; }
        public FoodAndDrinkDtoRequest() { }
    }
}
