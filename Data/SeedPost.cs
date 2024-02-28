using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedPost
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.Post.Any())
            {
                var posts = new List<Post>
            {
                new Post
                {
                    Name = "Exploring the Old Town of Sarajevo",
                    Description = "A journey through the historic streets of Sarajevo, uncovering its rich cultural heritage.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Baščaršija",
                        XCoordinate = 43.8594,
                        YCoordinate = 18.4306
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/sarajevo_old_town1.jpg" },
                        new Image { Url = "https://example.com/sarajevo_old_town2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Historical Sites" },
                        new Subcategory { Name = "Cultural Experience" }
                    }
                },
                new Post
                {
                    Name = "Hiking in the Una National Park",
                    Description = "An adventure-filled day exploring the stunning landscapes and waterfalls of the Una National Park.",
                    Location = new Location
                    {
                        City = "Bihać",
                        Address = "Una National Park",
                        XCoordinate = 44.7216,
                        YCoordinate = 16.1531
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/una_national_park1.jpg" },
                        new Image { Url = "https://example.com/una_national_park2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Nature" },
                    }
                },
                new Post
                {
                    Name = "Sunset Views from Stari Most",
                    Description = "Capturing the breathtaking sunset views overlooking the iconic Stari Most bridge in Mostar.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Old Bridge",
                        XCoordinate = 43.3378,
                        YCoordinate = 17.8146
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/mostar_stari_most1.jpg" },
                        new Image { Url = "https://example.com/mostar_stari_most2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Landmarks" },
                        new Subcategory { Name = "Photography" }
                    }
                }
            };

                await context.Post.AddRangeAsync(posts);
                await context.SaveChangesAsync();
            }
        }
    }


}
