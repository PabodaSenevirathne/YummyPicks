namespace YummyPicks.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public string FoodName { get; set; }
        public double Price { get; set; }
        public DateTime PublishingDate { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
