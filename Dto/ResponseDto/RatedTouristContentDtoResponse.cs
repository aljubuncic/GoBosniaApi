namespace GoTravnikApi.Dto.ResponseDto
{
    public class RatedTouristContentDtoResponse : TouristContentDtoResponse
    {
        public List<RatingDtoResponse> Ratings { get; set; }
        public RatedTouristContentDtoResponse()
        {
        }
    }
}
