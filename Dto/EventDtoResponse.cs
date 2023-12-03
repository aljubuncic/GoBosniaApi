namespace GoTravnikApi.Dto
{
    public class EventDtoResponse : TouristContentDtoResponse
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public EventDtoResponse()
        {
        }
    }
}
