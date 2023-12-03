namespace GoTravnikApi.Dto
{
    public class RatingDtoResponse
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string TextComment { get; set; }
        public DateTime PostDate { get; set; }
        public bool Approved { get; set; }
        public TouristContentDtoResponse TouristContent { get; set; }
        public RatingDtoResponse()
        {
        }
    }
}
