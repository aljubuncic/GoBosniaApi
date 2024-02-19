namespace GoTravnikApi.Dto.ResponseDto
{
    public class EventDtoResponse : TouristContentDtoResponse
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public EventDtoResponse()
        {
        }
    }
}
