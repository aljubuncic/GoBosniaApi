namespace GoTravnikApi.Dto
{
    public class RatingDtoRequest
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string TextComment { get; set; }

        public RatingDtoRequest()
        {
            
        }
    }
}
