using GoTravnikApi.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Reflection.Emit;

namespace GoTravnikApi.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Accommodation> Accommodation { get; set; }
        public DbSet<Activity> Activity { get; set; }
        public DbSet<Attraction> Attraction { get; set; }
        public DbSet<Event> Event { get; set; }
        public DbSet<FoodAndDrink> FoodAndDrink { get; set; }
        public DbSet<Location> Location { get; set; }
        public DbSet<Post> Post { get; set; }
        public DbSet<Rating> Rating { get; set; }
        public DbSet<Subcategory> Subcategory { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Accommodation>().ToTable(nameof(Accommodation));
            builder.Entity<Activity>().ToTable(nameof(Activity));
            builder.Entity<Attraction>().ToTable(nameof(Attraction));
            builder.Entity<Event>().ToTable(nameof(Event));
            builder.Entity<FoodAndDrink>().ToTable(nameof(FoodAndDrink));
            builder.Entity<Location>().ToTable(nameof(Location));
            builder.Entity<Post>().ToTable(nameof(Post));
            builder.Entity<Rating>().ToTable(nameof(Rating));
            builder.Entity<Subcategory>().ToTable(nameof(Subcategory));
            builder.Entity<Subcategory>()
                .HasIndex(subcategory => subcategory.Name)
                .IsUnique();
            base.OnModelCreating(builder);
        }

    }
}
