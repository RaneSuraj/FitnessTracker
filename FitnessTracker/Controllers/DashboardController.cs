using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class DashboardController : Controller
    {
        private bool CheckLogin()
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                TempData["Error"] = "Please login to access dashboard";
                return false;
            }
            return true;
        }

        public IActionResult Index()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var user = SessionHelper.GetUser(HttpContext.Session);
            var workouts = SessionHelper.GetWorkouts(HttpContext.Session);
            var meals = SessionHelper.GetMeals(HttpContext.Session);

            // Today's data
            var today = DateTime.Now.Date;
            var todayWorkouts = workouts.Where(w => w.WorkoutDate.Date == today).ToList();
            var todayMeals = meals.Where(m => m.MealDate.Date == today).ToList();

            // This week's data
            var startOfWeek = today.AddDays(-(int)today.DayOfWeek);
            var weekWorkouts = workouts.Where(w => w.WorkoutDate.Date >= startOfWeek).ToList();
            var weekMeals = meals.Where(m => m.MealDate.Date >= startOfWeek).ToList();

            // Calculate stats
            var dashboard = new DashboardViewModel
            {
                User = user,

                // Today's stats
                TodayCaloriesConsumed = todayMeals.Sum(m => m.Calories),
                TodayCaloriesBurned = todayWorkouts.Sum(w => w.CaloriesBurned ?? 0),
                TodayProtein = todayMeals.Sum(m => m.Protein ?? 0),
                TodayCarbs = todayMeals.Sum(m => m.Carbs ?? 0),
                TodayFat = todayMeals.Sum(m => m.Fat ?? 0),
                TodayWorkoutMinutes = todayWorkouts.Sum(w => w.DurationMinutes ?? 0),

                // This week's stats
                WeekCaloriesConsumed = weekMeals.Sum(m => m.Calories),
                WeekCaloriesBurned = weekWorkouts.Sum(w => w.CaloriesBurned ?? 0),
                WeekWorkouts = weekWorkouts.Count,
                WeekMeals = weekMeals.Count,

                // Total stats
                TotalWorkouts = workouts.Count,
                TotalMeals = meals.Count,

                // Recent items
                TodayWorkouts = todayWorkouts,
                TodayMeals = todayMeals,
                RecentWorkouts = workouts.OrderByDescending(w => w.WorkoutDate).Take(5).ToList(),
                RecentMeals = meals.OrderByDescending(m => m.MealDate).Take(5).ToList(),

                // Weekly breakdown for chart
                WeeklyData = GetWeeklyData(workouts, meals, startOfWeek)
            };

            return View(dashboard);
        }

        private List<DailyStats> GetWeeklyData(List<Workout> workouts, List<Meal> meals, DateTime startOfWeek)
        {
            var weeklyData = new List<DailyStats>();

            for (int i = 0; i < 7; i++)
            {
                var date = startOfWeek.AddDays(i);
                var dayWorkouts = workouts.Where(w => w.WorkoutDate.Date == date).ToList();
                var dayMeals = meals.Where(m => m.MealDate.Date == date).ToList();

                weeklyData.Add(new DailyStats
                {
                    Date = date,
                    DayName = date.ToString("ddd"),
                    CaloriesConsumed = dayMeals.Sum(m => m.Calories),
                    CaloriesBurned = dayWorkouts.Sum(w => w.CaloriesBurned ?? 0),
                    WorkoutCount = dayWorkouts.Count,
                    MealCount = dayMeals.Count
                });
            }

            return weeklyData;
        }
    }
}