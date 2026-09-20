using FitnessTracker.Models;
using System.Text.Json;

namespace FitnessTracker.Models
{
    public static class SessionHelper
    {
        private const string CurrentUserKey = "CurrentUser";
        private const string WorkoutsKey = "Workouts";
        private const string MealsKey = "Meals";

        // ===== USER SESSION METHODS =====
        public static void SetUser(ISession session, User user)
        {
            session.SetString(CurrentUserKey, JsonSerializer.Serialize(user));
        }

        public static User GetUser(ISession session)
        {
            var userJson = session.GetString(CurrentUserKey);
            return string.IsNullOrEmpty(userJson) ? null : JsonSerializer.Deserialize<User>(userJson);
        }

        public static bool IsLoggedIn(ISession session)
        {
            return session.GetString(CurrentUserKey) != null;
        }

        public static void ClearSession(ISession session)
        {
            session.Clear();
        }

        // ===== WORKOUT METHODS (USER-SPECIFIC) =====
        public static List<Workout> GetWorkouts(ISession session)
        {
            if (!IsLoggedIn(session)) return new List<Workout>();

            var user = GetUser(session);
            var workoutsJson = session.GetString(WorkoutsKey);

            if (string.IsNullOrEmpty(workoutsJson))
                return new List<Workout>();

            var allWorkouts = JsonSerializer.Deserialize<List<Workout>>(workoutsJson);

            // Return only workouts for the current user
            return allWorkouts.Where(w => w.UserId == user.Id).ToList();
        }

        public static void AddWorkout(ISession session, Workout workout)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allWorkouts = GetAllWorkouts(session);

            workout.Id = allWorkouts.Count > 0 ? allWorkouts.Max(w => w.Id) + 1 : 1;
            workout.UserId = user.Id; // Assign to current user
            workout.CreatedAt = DateTime.Now;

            allWorkouts.Add(workout);
            SaveAllWorkouts(session, allWorkouts);
        }

        public static Workout GetWorkoutById(ISession session, int id)
        {
            if (!IsLoggedIn(session)) return null;

            var user = GetUser(session);
            var workouts = GetWorkouts(session);

            // Ensure user can only access their own workouts
            return workouts.FirstOrDefault(w => w.Id == id && w.UserId == user.Id);
        }

        public static void UpdateWorkout(ISession session, Workout workout)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allWorkouts = GetAllWorkouts(session);
            var existing = allWorkouts.FirstOrDefault(w => w.Id == workout.Id && w.UserId == user.Id);

            if (existing != null)
            {
                existing.Title = workout.Title;
                existing.Description = workout.Description;
                existing.Type = workout.Type;
                existing.DurationMinutes = workout.DurationMinutes;
                existing.CaloriesBurned = workout.CaloriesBurned;
                existing.WorkoutDate = workout.WorkoutDate;
                existing.Icon = workout.Icon;

                SaveAllWorkouts(session, allWorkouts);
            }
        }

        public static void DeleteWorkout(ISession session, int id)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allWorkouts = GetAllWorkouts(session);

            // Only delete if it belongs to current user
            allWorkouts.RemoveAll(w => w.Id == id && w.UserId == user.Id);
            SaveAllWorkouts(session, allWorkouts);
        }

        private static List<Workout> GetAllWorkouts(ISession session)
        {
            var workoutsJson = session.GetString(WorkoutsKey);
            return string.IsNullOrEmpty(workoutsJson)
                ? new List<Workout>()
                : JsonSerializer.Deserialize<List<Workout>>(workoutsJson);
        }

        private static void SaveAllWorkouts(ISession session, List<Workout> workouts)
        {
            session.SetString(WorkoutsKey, JsonSerializer.Serialize(workouts));
        }

        // ===== MEAL METHODS (USER-SPECIFIC) =====
        public static List<Meal> GetMeals(ISession session)
        {
            if (!IsLoggedIn(session)) return new List<Meal>();

            var user = GetUser(session);
            var mealsJson = session.GetString(MealsKey);

            if (string.IsNullOrEmpty(mealsJson))
                return new List<Meal>();

            var allMeals = JsonSerializer.Deserialize<List<Meal>>(mealsJson);

            // Return only meals for the current user
            return allMeals.Where(m => m.UserId == user.Id).ToList();
        }

        public static void AddMeal(ISession session, Meal meal)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allMeals = GetAllMeals(session);

            meal.Id = allMeals.Count > 0 ? allMeals.Max(m => m.Id) + 1 : 1;
            meal.UserId = user.Id; // Assign to current user
            meal.CreatedAt = DateTime.Now;

            allMeals.Add(meal);
            SaveAllMeals(session, allMeals);
        }

        public static Meal GetMealById(ISession session, int id)
        {
            if (!IsLoggedIn(session)) return null;

            var user = GetUser(session);
            var meals = GetMeals(session);

            // Ensure user can only access their own meals
            return meals.FirstOrDefault(m => m.Id == id && m.UserId == user.Id);
        }

        public static void UpdateMeal(ISession session, Meal meal)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allMeals = GetAllMeals(session);
            var existing = allMeals.FirstOrDefault(m => m.Id == meal.Id && m.UserId == user.Id);

            if (existing != null)
            {
                existing.Name = meal.Name;
                existing.Description = meal.Description;
                existing.MealType = meal.MealType;
                existing.Calories = meal.Calories;
                existing.Protein = meal.Protein;
                existing.Carbs = meal.Carbs;
                existing.Fat = meal.Fat;
                existing.MealDate = meal.MealDate;
                existing.Icon = meal.Icon;

                SaveAllMeals(session, allMeals);
            }
        }

        public static void DeleteMeal(ISession session, int id)
        {
            if (!IsLoggedIn(session)) return;

            var user = GetUser(session);
            var allMeals = GetAllMeals(session);

            // Only delete if it belongs to current user
            allMeals.RemoveAll(m => m.Id == id && m.UserId == user.Id);
            SaveAllMeals(session, allMeals);
        }

        private static List<Meal> GetAllMeals(ISession session)
        {
            var mealsJson = session.GetString(MealsKey);
            return string.IsNullOrEmpty(mealsJson)
                ? new List<Meal>()
                : JsonSerializer.Deserialize<List<Meal>>(mealsJson);
        }

        private static void SaveAllMeals(ISession session, List<Meal> meals)
        {
            session.SetString(MealsKey, JsonSerializer.Serialize(meals));
        }
    }
}