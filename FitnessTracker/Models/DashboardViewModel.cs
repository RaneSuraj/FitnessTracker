namespace FitnessTracker.Models
{
    public class DashboardViewModel
    {
        public User User { get; set; }

        // Today's stats
        public int TodayCaloriesConsumed { get; set; }
        public int TodayCaloriesBurned { get; set; }
        public decimal TodayProtein { get; set; }
        public decimal TodayCarbs { get; set; }
        public decimal TodayFat { get; set; }
        public int TodayWorkoutMinutes { get; set; }

        // This week's stats
        public int WeekCaloriesConsumed { get; set; }
        public int WeekCaloriesBurned { get; set; }
        public int WeekWorkouts { get; set; }
        public int WeekMeals { get; set; }

        // Total stats
        public int TotalWorkouts { get; set; }
        public int TotalMeals { get; set; }

        // Lists
        public List<Workout> TodayWorkouts { get; set; }
        public List<Meal> TodayMeals { get; set; }
        public List<Workout> RecentWorkouts { get; set; }
        public List<Meal> RecentMeals { get; set; }

        // Weekly data for charts
        public List<DailyStats> WeeklyData { get; set; }

        // Calculated properties
        public int NetCaloriesToday => TodayCaloriesConsumed - TodayCaloriesBurned;
        public int NetCaloriesWeek => WeekCaloriesConsumed - WeekCaloriesBurned;
        public double AvgWorkoutDuration => TotalWorkouts > 0 ? TodayWorkoutMinutes / (double)TotalWorkouts : 0;
    }

    public class DailyStats
    {
        public DateTime Date { get; set; }
        public string DayName { get; set; }
        public int CaloriesConsumed { get; set; }
        public int CaloriesBurned { get; set; }
        public int WorkoutCount { get; set; }
        public int MealCount { get; set; }
        public int NetCalories => CaloriesConsumed - CaloriesBurned;
    }
}