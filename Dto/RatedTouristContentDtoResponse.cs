namespace GoTravnikApi.Dto
{
    public class RatedTouristContentDtoResponse : TouristContentDtoResponse
    {
        public List<RatingDtoResponse> Ratings { get; set; }
        public RatedTouristContentDtoResponse()
        {
        }
    }
}
