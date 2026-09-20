using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Models
{
    public class Workout
    {
        public int Id { get; set; }

        public int UserId { get; set; } // Links workout to user

        [Required(ErrorMessage = "Title is required")]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [Required(ErrorMessage = "Workout type is required")]
        [Display(Name = "Workout Type")]
        public string Type { get; set; }

        [Display(Name = "Duration (minutes)")]
        [Range(1, 1440, ErrorMessage = "Duration must be between 1 and 1440 minutes")]
        public int? DurationMinutes { get; set; }

        [Display(Name = "Calories Burned")]
        [Range(0, 10000, ErrorMessage = "Calories must be between 0 and 10000")]
        public int? CaloriesBurned { get; set; }

        [Display(Name = "Workout Date")]
        [DataType(DataType.Date)]
        public DateTime WorkoutDate { get; set; } = DateTime.Now;

        public string Icon { get; set; } = "🏋️";

        public DateTime CreatedAt { get; set; }
    }
}