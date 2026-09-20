using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class BMICalculatorModel
    {
        [Required(ErrorMessage = "Weight is required")]
        [Range(20, 300, ErrorMessage = "Weight must be between 20 and 300 kg")]
        public double Weight { get; set; }

        [Required(ErrorMessage = "Height is required")]
        [Range(100, 250, ErrorMessage = "Height must be between 100 and 250 cm")]
        public double Height { get; set; }

        public double BMI { get; set; }
        public string Category { get; set; } = string.Empty;
        public string CategoryColor { get; set; } = string.Empty;
        public string Recommendation { get; set; } = string.Empty;
        public string HealthStatus { get; set; } = string.Empty; // NEW PROPERTY
    }
}