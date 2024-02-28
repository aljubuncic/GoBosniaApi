using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedActivity
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.Activity.Any())
            {
                var activities = new List<Activity>
            {
                new Activity
                {
                    Name = "Sarajevo Walking Tour",
                    Description = "Explore the rich history of Sarajevo on foot with a knowledgeable guide.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Meeting Point: Old Town Square",
                        XCoordinate = 43.8563,
                        YCoordinate = 18.4131
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/activity1.jpg" },
                        new Image { Url = "https://example.com/activity2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Walking Tours" }
                    }
                },
                new Activity
                {
                    Name = "Rafting on the Una River",
                    Description = "Experience thrilling whitewater rafting on the beautiful Una River.",
                    Location = new Location
                    {
                        City = "Bihac",
                        Address = "Una River",
                        XCoordinate = 44.8169,
                        YCoordinate = 15.8700
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/rafting1.jpg" },
                        new Image { Url = "https://example.com/rafting2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Rafting" }
                    }
                },
                new Activity
                {
                    Name = "Mostar Old Bridge Tour",
                    Description = "Discover the iconic Old Bridge of Mostar and its fascinating history.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Old Bridge",
                        XCoordinate = 43.3378,
                        YCoordinate = 17.8129
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/mostar1.jpg" },
                        new Image { Url = "https://example.com/mostar2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Sightseeing Tours" }
                    }
                }
            };

                await context.Activity.AddRangeAsync(activities);
                await context.SaveChangesAsync();
            }
        }
    }

}
