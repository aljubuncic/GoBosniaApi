namespace GoTravnikApi.Data
{
    public static class SeedData
    {
        public static async Task Initialize(DataContext context)
        {
            await SeedAccommodation.Initialize(context);
            await SeedActivity.Initialize(context);
            await SeedAttraction.Initialize(context); 
            await SeedEvent.Initialize(context);  
            await SeedFoodAndDrink.Initialize(context);   
            await SeedPost.Initialize(context);
        }
    }
}
