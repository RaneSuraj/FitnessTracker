namespace FitnessTracker.Models
{
    public class MealOption
    {
        public string Name { get; set; }
        public string Icon { get; set; }
        public string MealType { get; set; }
        public int Calories { get; set; }
        public decimal Protein { get; set; }
        public decimal Carbs { get; set; }
        public decimal Fat { get; set; }
    }

    public static class MealOptions
    {
        public static List<MealOption> GetAll()
        {
            return new List<MealOption>
            {
                // Breakfast
                new MealOption { Name = "Oatmeal with Fruits", Icon = "🥣", MealType = "Breakfast", Calories = 350, Protein = 12, Carbs = 58, Fat = 8 },
                new MealOption { Name = "Eggs & Toast", Icon = "🍳", MealType = "Breakfast", Calories = 300, Protein = 18, Carbs = 28, Fat = 12 },
                new MealOption { Name = "Smoothie Bowl", Icon = "🥤", MealType = "Breakfast", Calories = 280, Protein = 10, Carbs = 45, Fat = 6 },
                new MealOption { Name = "Pancakes", Icon = "🥞", MealType = "Breakfast", Calories = 450, Protein = 12, Carbs = 68, Fat = 14 },
                new MealOption { Name = "Avocado Toast", Icon = "🥑", MealType = "Breakfast", Calories = 320, Protein = 10, Carbs = 35, Fat = 16 },
                
                // Lunch
                new MealOption { Name = "Grilled Chicken Salad", Icon = "🥗", MealType = "Lunch", Calories = 420, Protein = 38, Carbs = 22, Fat = 18 },
                new MealOption { Name = "Rice & Curry", Icon = "🍛", MealType = "Lunch", Calories = 550, Protein = 25, Carbs = 75, Fat = 15 },
                new MealOption { Name = "Chicken Sandwich", Icon = "🥪", MealType = "Lunch", Calories = 480, Protein = 30, Carbs = 45, Fat = 18 },
                new MealOption { Name = "Pasta with Vegetables", Icon = "🍝", MealType = "Lunch", Calories = 500, Protein = 18, Carbs = 68, Fat = 16 },
                new MealOption { Name = "Fish & Chips", Icon = "🐟", MealType = "Lunch", Calories = 620, Protein = 32, Carbs = 55, Fat = 28 },
                new MealOption { Name = "Buddha Bowl", Icon = "🥙", MealType = "Lunch", Calories = 450, Protein = 22, Carbs = 52, Fat = 18 },
                
                // Dinner
                new MealOption { Name = "Grilled Salmon", Icon = "🍣", MealType = "Dinner", Calories = 480, Protein = 40, Carbs = 15, Fat = 28 },
                new MealOption { Name = "Steak with Veggies", Icon = "🥩", MealType = "Dinner", Calories = 550, Protein = 45, Carbs = 20, Fat = 32 },
                new MealOption { Name = "Vegetable Stir-Fry", Icon = "🥘", MealType = "Dinner", Calories = 380, Protein = 15, Carbs = 48, Fat = 14 },
                new MealOption { Name = "Chicken Breast & Rice", Icon = "🍗", MealType = "Dinner", Calories = 520, Protein = 42, Carbs = 55, Fat = 12 },
                new MealOption { Name = "Pizza", Icon = "🍕", MealType = "Dinner", Calories = 680, Protein = 28, Carbs = 78, Fat = 28 },
                new MealOption { Name = "Burger", Icon = "🍔", MealType = "Dinner", Calories = 720, Protein = 32, Carbs = 65, Fat = 35 },
                
                // Snacks
                new MealOption { Name = "Protein Bar", Icon = "🍫", MealType = "Snack", Calories = 220, Protein = 18, Carbs = 25, Fat = 8 },
                new MealOption { Name = "Fruits", Icon = "🍎", MealType = "Snack", Calories = 120, Protein = 2, Carbs = 28, Fat = 1 },
                new MealOption { Name = "Nuts & Seeds", Icon = "🥜", MealType = "Snack", Calories = 180, Protein = 6, Carbs = 8, Fat = 15 },
                new MealOption { Name = "Yogurt", Icon = "🍦", MealType = "Snack", Calories = 150, Protein = 10, Carbs = 20, Fat = 4 },
                new MealOption { Name = "Protein Shake", Icon = "🥤", MealType = "Snack", Calories = 200, Protein = 25, Carbs = 15, Fat = 5 },
                
                // Other (user custom)
                new MealOption { Name = "Other", Icon = "➕", MealType = "Custom", Calories = 0, Protein = 0, Carbs = 0, Fat = 0 }
            };
        }

        public static List<MealOption> GetByType(string mealType)
        {
            return GetAll().Where(m => m.MealType == mealType || m.MealType == "Custom").ToList();
        }
    }
}