namespace GoTravnikApi.Dto
{
    public class EventTripPlannerDto
    {
        public List<string> SubcategoryNames { get; set; }  
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public EventTripPlannerDto()
        {
            
        }
    }
}
