namespace GoTravnikApi.Models
{
    public class GastroPlace
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public Location Location { get; set; }
        public Rating Rating { get; set; }
    }
}
