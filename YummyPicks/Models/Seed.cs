using Microsoft.EntityFrameworkCore;
using YummyPicks.Data;
using YummyPicks.Models;

namespace YummyPicks.Models
{
    public class Seed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new YummyPicksContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<YummyPicksContext>>()))
            {
                // Look for any review.
                if (context.Review.Any())
                {
                    return;   // DB has been seeded
                }
                context.Review.AddRange(
                    new Review
                    {
                        RestaurantName = "ZestSpot",
                        FoodName = "Spaghetti",
                        Price = 15.99,
                        PublishingDate = DateTime.Parse("2022-10-15"),
                        Image = File.ReadAllBytes("wwwroot/images/pizza.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "YumLoom",
                        FoodName = "Pasta",
                        Price = 22.50,
                        PublishingDate = DateTime.Parse("2022-11-05"),
                        Image = File.ReadAllBytes("wwwroot/images/pasta.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "FlavorNest",
                        FoodName = "Salad",
                        Price = 12.75,
                        PublishingDate = DateTime.Parse("2022-09-20"),
                        Image = File.ReadAllBytes("wwwroot/images/salad.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "SavvySpoon",
                        FoodName = "Rice",
                        Price = 18.99,
                        PublishingDate = DateTime.Parse("2023-01-08"),
                        Image = File.ReadAllBytes("wwwroot/images/rice.jpg")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
