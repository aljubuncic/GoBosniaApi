using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedAttraction
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.Attraction.Any())
            {
                var attractions = new List<Attraction>
            {
                new Attraction
                {
                    Name = "Stari Most (Old Bridge)",
                    Description = "The iconic Old Bridge in Mostar, a UNESCO World Heritage Site.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Old Bridge",
                        XCoordinate = 43.3378,
                        YCoordinate = 17.8129
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/mostar_old_bridge1.jpg" },
                        new Image { Url = "https://example.com/mostar_old_bridge2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Historical Landmarks" },
                        new Subcategory { Name = "Sightseeing Spots" }
                    }
                },
                new Attraction
                {
                    Name = "Kravice Waterfalls",
                    Description = "A stunning series of waterfalls on the Trebižat River near Mostar.",
                    Location = new Location
                    {
                        City = "Ljubuški",
                        Address = "Kravice",
                        XCoordinate = 43.1753,
                        YCoordinate = 17.5939
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/kravice_waterfalls1.jpg" },
                        new Image { Url = "https://example.com/kravice_waterfalls2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Natural Landmarks" },
                        new Subcategory { Name = "Outdoor Attractions" }
                    }
                },
                new Attraction
                {
                    Name = "Bosnian National Monument Muslibegović House",
                    Description = "A beautifully preserved Ottoman-era house in Mostar.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Kujundžiluk Street",
                        XCoordinate = 43.3375,
                        YCoordinate = 17.8132
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/muslibegovic_house1.jpg" },
                        new Image { Url = "https://example.com/muslibegovic_house2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Museums" },
                        new Subcategory { Name = "Cultural Sites" }
                    }
                }
            };

                await context.Attraction.AddRangeAsync(attractions);
                await context.SaveChangesAsync();
            }
        }
    }

}
