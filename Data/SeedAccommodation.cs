using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedAccommodation
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.Accommodation.Any())
            {
                var accommodations = new List<Accommodation>
            {
                new Accommodation
                {
                    Name = "Hotel Sarajevo",
                    Description = "A luxurious hotel in the heart of Sarajevo.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Main Street 123",
                        XCoordinate = 43.8563,
                        YCoordinate = 18.4131
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/image1.jpg" },
                        new Image { Url = "https://example.com/image2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Hotels" }
                    },
                    Website = "https://hotelsarajevo.com",
                    TelephoneNumber = "+387 33 123 456"
                },
                new Accommodation
                {
                    Name = "Mountain Lodge",
                    Description = "Cozy lodge nestled in the mountains.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Mountain Road 456",
                        XCoordinate = 43.7465,
                        YCoordinate = 18.2959
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/lodge1.jpg" },
                        new Image { Url = "https://example.com/lodge2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Lodges" }
                    },
                    Website = "https://mountainlodge.com",
                    TelephoneNumber = "+387 33 789 012"
                },
                new Accommodation
                {
                    Name = "River House",
                    Description = "Riverside retreat for nature lovers.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Riverside Avenue 789",
                        XCoordinate = 43.3439,
                        YCoordinate = 17.8078
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/riverhouse1.jpg" },
                        new Image { Url = "https://example.com/riverhouse2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Houses" }
                    },
                    Website = "https://riverhouse.com",
                    TelephoneNumber = "+387 36 234 567"
                }
            };

                await context.Accommodation.AddRangeAsync(accommodations);
                await context.SaveChangesAsync();
            }
        }
    }

}
