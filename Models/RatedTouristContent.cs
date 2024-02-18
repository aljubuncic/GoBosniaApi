namespace GoTravnikApi.Models
{
    public abstract class RatedTouristContent : TouristContent
    {
        public List<Rating> Ratings { get; set; }
        public RatedTouristContent()
        {
        }
        public RatedTouristContent(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, List<Rating> ratings) 
            : base(id, name, description, location, images, subcatgeories)
        {
            Ratings = ratings;
        }

    }
}
