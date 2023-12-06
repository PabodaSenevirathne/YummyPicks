using System.ComponentModel.DataAnnotations;

namespace YummyPicks.Models
{
    public class ReviewViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string RestaurantName { get; set; }

        [Required]
        [StringLength(60, MinimumLength = 3)]
        public string FoodName { get; set; }
        [RegularExpression(@"^\d{1,7}(?:\.\d{1,2})?$", ErrorMessage = "Invalid price format.")]
        public double Price { get; set; }
        public DateTime PublishingDate { get; set; }
        public IFormFile? Photo { get; set; }
    }
}
