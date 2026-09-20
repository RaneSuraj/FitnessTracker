namespace FitnessTracker.Models
{
    public static class DataStore
    {
        // In-memory storage for users
        private static List<User> users = new List<User>
        {
            new User
            {
                Id = 1,
                FullName = "Demo User",
                Email = "demo@befit.com",
                Password = "demo123",
                Age = 28,
                Gender = "Male",
                Weight = 75,
                Height = 175,
                CreatedAt = DateTime.Now
            }
        };

        // In-memory storage for workouts
        private static List<Workout> workouts = new List<Workout>();

        // In-memory storage for meals
        private static List<Meal> meals = new List<Meal>();

        // User Methods
        public static List<User> GetUsers()
        {
            return users;
        }

        public static User GetUserById(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public static User GetUserByEmail(string email)
        {
            return users.FirstOrDefault(u => u.Email.ToLower() == email.ToLower());
        }

        public static void AddUser(User user)
        {
            user.Id = users.Count > 0 ? users.Max(u => u.Id) + 1 : 1;
            user.CreatedAt = DateTime.Now;
            users.Add(user);
        }

        public static void UpdateUser(User user)
        {
            var existing = users.FirstOrDefault(u => u.Id == user.Id);
            if (existing != null)
            {
                existing.FullName = user.FullName;
                existing.Email = user.Email;
                existing.Age = user.Age;
                existing.Gender = user.Gender;
                existing.Weight = user.Weight;
                existing.Height = user.Height;
            }
        }

        // Workout Methods
        public static List<Workout> GetWorkouts()
        {
            return workouts;
        }

        public static List<Workout> GetWorkoutsByUserId(int userId)
        {
            return workouts.Where(w => w.UserId == userId).ToList();
        }

        public static Workout GetWorkoutById(int id)
        {
            return workouts.FirstOrDefault(w => w.Id == id);
        }

        public static void AddWorkout(Workout workout)
        {
            workout.Id = workouts.Count > 0 ? workouts.Max(w => w.Id) + 1 : 1;
            workout.CreatedAt = DateTime.Now;
            workouts.Add(workout);
        }

        public static void UpdateWorkout(Workout workout)
        {
            var existing = workouts.FirstOrDefault(w => w.Id == workout.Id);
            if (existing != null)
            {
                existing.Title = workout.Title;
                existing.Description = workout.Description;
                existing.Type = workout.Type;
                existing.DurationMinutes = workout.DurationMinutes;
                existing.CaloriesBurned = workout.CaloriesBurned;
                existing.WorkoutDate = workout.WorkoutDate;
                existing.Icon = workout.Icon;
            }
        }

        public static void DeleteWorkout(int id)
        {
            workouts.RemoveAll(w => w.Id == id);
        }

        // Meal Methods
        public static List<Meal> GetMeals()
        {
            return meals;
        }

        public static List<Meal> GetMealsByUserId(int userId)
        {
            return meals.Where(m => m.UserId == userId).ToList();
        }

        public static Meal GetMealById(int id)
        {
            return meals.FirstOrDefault(m => m.Id == id);
        }

        public static void AddMeal(Meal meal)
        {
            meal.Id = meals.Count > 0 ? meals.Max(m => m.Id) + 1 : 1;
            meal.CreatedAt = DateTime.Now;
            meals.Add(meal);
        }

        public static void UpdateMeal(Meal meal)
        {
            var existing = meals.FirstOrDefault(m => m.Id == meal.Id);
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
            }
        }

        public static void DeleteMeal(int id)
        {
            meals.RemoveAll(m => m.Id == id);
        }
    }
}