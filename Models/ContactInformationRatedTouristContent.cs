namespace GoTravnikApi.Models
{
    public abstract class ContactInformationRatedTouristContent : RatedTouristContent
    {
        public string? Website { get; set; }
        public string TelephoneNumber { get; set; }

        public ContactInformationRatedTouristContent()
        {
        }

        public ContactInformationRatedTouristContent(int id, string name, string description, Location location, List<Image> images, List<Subcategory> subcatgeories, List<Rating> ratings, string? website, string telephoneNumber) 
            : base(id, name, description, location, images, subcatgeories, ratings)
        {
            Website = website;
            TelephoneNumber = telephoneNumber;
        }
    }
}
