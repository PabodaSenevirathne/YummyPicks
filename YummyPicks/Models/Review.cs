using System.ComponentModel.DataAnnotations;

namespace YummyPicks.Models
{
    public class Review
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Restaurant name is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Restaurant name must be between 3 and 60 characters.")]
        public string RestaurantName { get; set; }

        [Required(ErrorMessage = "Food name is required.")]
        [StringLength(60, MinimumLength = 3, ErrorMessage = "Food name must be between 3 and 60 characters.")]
        public string FoodName { get; set; }
        [Required(ErrorMessage = "Price is required.")]
        [Range(0, 9999999.99, ErrorMessage = "Price must be between 0 and 9999999.99")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Publishing date is required.")]
        public DateTime PublishingDate { get; set; }
        public byte[] Image { get; set; }
    }
}
