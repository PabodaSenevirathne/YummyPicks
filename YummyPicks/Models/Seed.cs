using Microsoft.EntityFrameworkCore;
using YummyPicks.Data;

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
                        RestaurantName = "Delicious Bites",
                        FoodName = "Spaghetti Carbonara",
                        Price = 15.99,
                        PublishingDate = DateTime.Parse("2022-10-15"),
                        //Image = GetImageData("spaghetti.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "Tasty Haven",
                        FoodName = "Grilled Salmon",
                        Price = 22.50,
                        PublishingDate = DateTime.Parse("2022-11-05"),
                        //Image = GetImageData("salmon.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "Sizzle Delight",
                        FoodName = "Margherita Pizza",
                        Price = 12.75,
                        PublishingDate = DateTime.Parse("2022-09-20"),
                        //Image = GetImageData("pizza.jpg")
                    },
                    new Review
                    {
                        RestaurantName = "Spicy Bites",
                        FoodName = "Chicken Curry",
                        Price = 18.99,
                        PublishingDate = DateTime.Parse("2023-01-08"),
                        //Image = GetImageData("curry.jpg")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
