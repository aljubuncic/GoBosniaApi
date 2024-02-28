using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedEvent
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.Event.Any())
            {
                var events = new List<Event>
            {
                new Event
                {
                    Name = "Sarajevo Film Festival",
                    Description = "Annual film festival showcasing the best of regional and international cinema.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Various venues",
                        XCoordinate = 43.8563,
                        YCoordinate = 18.4131
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/sarajevo_film_festival1.jpg" },
                        new Image { Url = "https://example.com/sarajevo_film_festival2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Film Festivals" },
                        new Subcategory { Name = "Cultural Events" }
                    },
                    StartDate = DateTime.Today.AddDays(30),  // Start date 30 days from now
                    EndDate = DateTime.Today.AddDays(37)     // End date 37 days from now
                },
                new Event
                {
                    Name = "International Folklore Festival",
                    Description = "Celebration of traditional music and dance from around the world.",
                    Location = new Location
                    {
                        City = "Banja Luka",
                        Address = "City Center",
                        XCoordinate = 44.7758,
                        YCoordinate = 17.1853
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/folklore_festival1.jpg" },
                        new Image { Url = "https://example.com/folklore_festival2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Music Festivals" }
                    },
                    StartDate = DateTime.Today.AddDays(45),  // Start date 45 days from now
                    EndDate = DateTime.Today.AddDays(50)     // End date 50 days from now
                },
                new Event
                {
                    Name = "Mostar Summer Fest",
                    Description = "Annual music festival featuring local and international artists.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Old Town Square",
                        XCoordinate = 43.3378,
                        YCoordinate = 17.8129
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "https://example.com/mostar_summer_fest1.jpg" },
                        new Image { Url = "https://example.com/mostar_summer_fest2.jpg" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Outdoor Events" }
                    },
                    StartDate = DateTime.Today.AddDays(60),  // Start date 60 days from now
                    EndDate = DateTime.Today.AddDays(65)     // End date 65 days from now
                }
            };

                await context.Event.AddRangeAsync(events);
                await context.SaveChangesAsync();
            }
        }
    }

}
