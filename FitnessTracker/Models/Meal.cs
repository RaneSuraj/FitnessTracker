using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Meal
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Links meal to user

        [Required(ErrorMessage = "Meal name is required")]
        [StringLength(100)]
        [Display(Name = "Meal Name")]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Meal type is required")]
        [Display(Name = "Meal Type")]
        public string MealType { get; set; }

        [Required(ErrorMessage = "Calories are required")]
        [Range(0, 5000, ErrorMessage = "Calories must be between 0 and 5000")]
        public int Calories { get; set; }

        [Display(Name = "Protein (g)")]
        [Range(0, 500, ErrorMessage = "Protein must be between 0 and 500g")]
        public decimal? Protein { get; set; }

        [Display(Name = "Carbs (g)")]
        [Range(0, 500, ErrorMessage = "Carbs must be between 0 and 500g")]
        public decimal? Carbs { get; set; }

        [Display(Name = "Fat (g)")]
        [Range(0, 500, ErrorMessage = "Fat must be between 0 and 500g")]
        public decimal? Fat { get; set; }

        [Display(Name = "Meal Date")]
        [DataType(DataType.Date)]
        public DateTime MealDate { get; set; } = DateTime.Now;

        public string Icon { get; set; } = "🍽️";

        public DateTime CreatedAt { get; set; }
    }
}