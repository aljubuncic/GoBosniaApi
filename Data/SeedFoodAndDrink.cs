using GoTravnikApi.Models;

namespace GoTravnikApi.Data
{
    public static class SeedFoodAndDrink
    {
        public static async Task Initialize(DataContext context)
        {
            if (!context.FoodAndDrink.Any())
            {
                List<FoodAndDrink> foodAndDrinks = new List<FoodAndDrink>
            {
                new FoodAndDrink
                {
                    Name = "Burek",
                    Description = "Burek is a traditional Bosnian pastry filled with meat, cheese, or spinach.",
                    Location = new Location
                    {
                        City = "Mostar",
                        Address = "Sample Address 2",
                        XCoordinate = 43.3423, // Sample coordinates for Mostar
                        YCoordinate = 17.8081
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "sample-url-3" },
                        new Image { Url = "sample-url-4" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Street Food" }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating { Value = 4, TextComment = "Great taste!" }
                    },
                    Website = "https://example.com/burek",
                    TelephoneNumber = "987654321"
                },
                new FoodAndDrink
                {
                    Name = "Bosanski Lonac",
                    Description = "Bosanski Lonac is a traditional Bosnian meat and vegetable stew.",
                    Location = new Location
                    {
                        City = "Sarajevo",
                        Address = "Sample Address 3",
                        XCoordinate = 43.8563, // Sample coordinates for Sarajevo
                        YCoordinate = 18.4131
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "sample-url-5" },
                        new Image { Url = "sample-url-6" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Traditional Cuisine" }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating { Value = 4, TextComment = "Delicious stew!" }
                    },
                    Website = "https://example.com/bosanski-lonac",
                    TelephoneNumber = "543216789"
                },
                new FoodAndDrink
                {
                    Name = "Grilled Fish",
                    Description = "Grilled fish is a popular dish in Bosnia and Herzegovina, often served with fresh vegetables.",
                    Location = new Location
                    {
                        City = "Neum",
                        Address = "Sample Address 4",
                        XCoordinate = 42.9199, // Sample coordinates for Neum
                        YCoordinate = 17.6147
                    },
                    Images = new List<Image>
                    {
                        new Image { Url = "sample-url-7" },
                        new Image { Url = "sample-url-8" }
                    },
                    Subcategories = new List<Subcategory>
                    {
                        new Subcategory { Name = "Seafood" },
                        new Subcategory { Name = "Local Delicacy" }
                    },
                    Ratings = new List<Rating>
                    {
                        new Rating { Value = 5, TextComment = "Fresh and tasty!" }
                    },
                    Website = "https://example.com/grilled-fish",
                    TelephoneNumber = "987123456"
                }
            };
                
                await context.FoodAndDrink.AddRangeAsync(foodAndDrinks);
                await context.SaveChangesAsync();
            }
        }
    }

}
