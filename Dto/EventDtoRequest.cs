namespace GoTravnikApi.Dto
{
    public class EventDtoRequest : TouristContentDtoRequest
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public EventDtoRequest()
        {
        }
    }
}
