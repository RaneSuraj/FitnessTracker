namespace FitnessTracker.Models
{
    public class ExerciseOption
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Type { get; set; }
        public int CaloriesPerHour { get; set; }
    }

    public static class ExerciseOptions
    {
        public static List<ExerciseOption> GetAll()
        {
            return new List<ExerciseOption>
            {
                // Cardio
                new ExerciseOption { Name = "Running", Icon = "🏃", Type = "Cardio", CaloriesPerHour = 600 },
                new ExerciseOption { Name = "Walking", Icon = "🚶", Type = "Cardio", CaloriesPerHour = 280 },
                new ExerciseOption { Name = "Cycling", Icon = "🚴", Type = "Cardio", CaloriesPerHour = 500 },
                new ExerciseOption { Name = "Swimming", Icon = "🏊", Type = "Cardio", CaloriesPerHour = 550 },
                new ExerciseOption { Name = "Jump Rope", Icon = "🪢", Type = "Cardio", CaloriesPerHour = 700 },
                new ExerciseOption { Name = "Dancing", Icon = "💃", Type = "Cardio", CaloriesPerHour = 400 },
                new ExerciseOption { Name = "Aerobics", Icon = "🤸", Type = "Cardio", CaloriesPerHour = 450 },
                
                // Strength
                new ExerciseOption { Name = "Weight Lifting", Icon = "🏋️", Type = "Strength", CaloriesPerHour = 350 },
                new ExerciseOption { Name = "Push-ups", Icon = "💪", Type = "Strength", CaloriesPerHour = 280 },
                new ExerciseOption { Name = "Pull-ups", Icon = "🦾", Type = "Strength", CaloriesPerHour = 300 },
                new ExerciseOption { Name = "Squats", Icon = "🦵", Type = "Strength", CaloriesPerHour = 320 },
                new ExerciseOption { Name = "Bench Press", Icon = "🏋️", Type = "Strength", CaloriesPerHour = 340 },
                
                // Flexibility
                new ExerciseOption { Name = "Yoga", Icon = "🧘", Type = "Flexibility", CaloriesPerHour = 200 },
                new ExerciseOption { Name = "Pilates", Icon = "🤸", Type = "Flexibility", CaloriesPerHour = 250 },
                new ExerciseOption { Name = "Stretching", Icon = "🙆", Type = "Flexibility", CaloriesPerHour = 150 },
                
                // Sports
                new ExerciseOption { Name = "Basketball", Icon = "🏀", Type = "Sports", CaloriesPerHour = 480 },
                new ExerciseOption { Name = "Football", Icon = "⚽", Type = "Sports", CaloriesPerHour = 500 },
                new ExerciseOption { Name = "Tennis", Icon = "🎾", Type = "Sports", CaloriesPerHour = 420 },
                new ExerciseOption { Name = "Cricket", Icon = "🏏", Type = "Sports", CaloriesPerHour = 350 },
                new ExerciseOption { Name = "Badminton", Icon = "🏸", Type = "Sports", CaloriesPerHour = 400 },
                
                // Other (user custom)
                new ExerciseOption { Name = "Other", Icon = "➕", Type = "Custom", CaloriesPerHour = 0 }
            };
        }
    }
}