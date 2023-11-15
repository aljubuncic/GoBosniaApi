namespace GoTravnikApi.Dto
{
    public class EventDto : TouristContentDto
    {
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }

        public EventDto()
        {
        }
    }
}
