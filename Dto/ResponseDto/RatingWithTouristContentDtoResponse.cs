namespace GoTravnikApi.Dto.ResponseDto
{
    public class RatingWithTouristContentDtoResponse : RatingDtoResponse
    {
        public RatedTouristContentDtoResponse TouristContent { get; set; }
        public RatingWithTouristContentDtoResponse()
        { 
        }
    }
}
