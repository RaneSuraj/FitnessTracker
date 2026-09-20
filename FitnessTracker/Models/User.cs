using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Full name is required")]
        [StringLength(100)]
        [Display(Name = "Full Name")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be at least 6 characters")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Age")]
        [Range(1, 120, ErrorMessage = "Age must be between 1 and 120")]
        public int? Age { get; set; }

        [Display(Name = "Gender")]
        public string Gender { get; set; }

        [Display(Name = "Weight (kg)")]
        [Range(1, 500, ErrorMessage = "Weight must be between 1 and 500 kg")]
        public decimal? Weight { get; set; }

        [Display(Name = "Height (cm)")]
        [Range(1, 300, ErrorMessage = "Height must be between 1 and 300 cm")]
        public decimal? Height { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}