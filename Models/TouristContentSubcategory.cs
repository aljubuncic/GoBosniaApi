using System.ComponentModel.DataAnnotations;

namespace GoTravnikApi.Models
{
    public class TouristContentSubcategory
    {
        [Key]
            public int Id { get; set; }
            public int TouristContentId { get; set; }
            public int SubcategoryId { get; set; }
            public TouristContent TouristContent { get; set; }

            public Subcategory Subcategory { get; set; }

        public TouristContentSubcategory(TouristContent touristContent, Subcategory subcategory)
        {
            TouristContent = touristContent;
            Subcategory = subcategory;
        }

        public TouristContentSubcategory()
        {
        }
    }
}
