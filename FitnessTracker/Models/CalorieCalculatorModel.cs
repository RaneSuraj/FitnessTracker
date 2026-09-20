using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class CalorieCalculatorModel
    {
        [Required(ErrorMessage = "Age is required")]
        [Range(15, 100, ErrorMessage = "Age must be between 15 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; }

        [Required(ErrorMessage = "Weight is required")]
        [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Range(100, 250, ErrorMessage = "Height must be between 100 and 250 cm")]
        public double Height { get; set; }

        [Required(ErrorMessage = "Activity level is required")]
        public string ActivityLevel { get; set; }

        [Required(ErrorMessage = "Goal is required")]
        public string Goal { get; set; }

        // Results
        public double BMR { get; set; }
        public double TDEE { get; set; }
        public double DailyCalories { get; set; }
        public string GoalDescription { get; set; } = string.Empty;
        public double ProteinGrams { get; set; }
        public double CarbsGrams { get; set; }
        public double FatGrams { get; set; }
    }
}