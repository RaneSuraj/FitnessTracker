using Microsoft.AspNetCore.Mvc;
using FitnessTracker.Models;

namespace FitnessTracker.Controllers
{
    public class CalculatorController : Controller
    {
        // BMI Calculator - GET
        public IActionResult BMI()
        {
            return View();
        }

        // BMI Calculator - POST
        [HttpPost]
        public IActionResult BMI(BMICalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate BMI
                double heightInMeters = model.Height / 100; // Convert cm to meters
                model.BMI = model.Weight / (heightInMeters * heightInMeters);

                // Determine BMI Category, Health Status, and Recommendation
                if (model.BMI < 18.5)
                {
                    model.Category = "Underweight";
                    model.CategoryColor = "#3b82f6"; // Blue
                    model.HealthStatus = "You are underweight. This may indicate nutritional deficiency or underlying health issues.";
                    model.Recommendation = "You may need to gain weight. Consult with a healthcare provider for a proper diet plan. Focus on nutrient-dense foods and strength training exercises.";
                }
                else if (model.BMI >= 18.5 && model.BMI < 25)
                {
                    model.Category = "Normal Weight";
                    model.CategoryColor = "#10b981"; // Green
                    model.HealthStatus = "You have a healthy weight! Your BMI is within the normal range.";
                    model.Recommendation = "Great! You're at a healthy weight. Maintain your current lifestyle with balanced diet and regular exercise. Keep up the good work!";
                }
                else if (model.BMI >= 25 && model.BMI < 30)
                {
                    model.Category = "Overweight";
                    model.CategoryColor = "#f59e0b"; // Orange
                    model.HealthStatus = "You are overweight. This may increase your risk of developing health conditions.";
                    model.Recommendation = "Consider adopting a healthier diet and increasing physical activity to reach a healthy weight. Small lifestyle changes can make a big difference.";
                }
                else
                {
                    model.Category = "Obese";
                    model.CategoryColor = "#ef4444"; // Red
                    model.HealthStatus = "You are obese. This significantly increases your risk of serious health conditions including diabetes, heart disease, and stroke.";
                    model.Recommendation = "It's important to consult with a healthcare provider for a personalized weight loss plan. Consider working with a dietitian and fitness professional for best results.";
                }
            }

            return View(model);
        }

        // Calorie Calculator - GET
        public IActionResult Calorie()
        {
            return View();
        }

        // Calorie Calculator - POST
        [HttpPost]
        public IActionResult Calorie(CalorieCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                // Calculate BMR using Mifflin-St Jeor Equation
                if (model.Gender == "Male")
                {
                    model.BMR = (10 * model.Weight) + (6.25 * model.Height) - (5 * model.Age) + 5;
                }
                else // Female
                {
                    model.BMR = (10 * model.Weight) + (6.25 * model.Height) - (5 * model.Age) - 161;
                }

                // Calculate TDEE based on activity level
                double activityMultiplier = model.ActivityLevel switch
                {
                    "Sedentary" => 1.2,
                    "Light" => 1.375,
                    "Moderate" => 1.55,
                    "Active" => 1.725,
                    "VeryActive" => 1.9,
                    _ => 1.2
                };

                model.TDEE = model.BMR * activityMultiplier;

                // Calculate calorie goals based on goal type
                switch (model.Goal)
                {
                    case "Lose":
                        model.DailyCalories = model.TDEE - 500; // Deficit for weight loss
                        model.GoalDescription = "Weight Loss (0.5 kg per week)";
                        break;
                    case "Maintain":
                        model.DailyCalories = model.TDEE;
                        model.GoalDescription = "Maintain Current Weight";
                        break;
                    case "Gain":
                        model.DailyCalories = model.TDEE + 500; // Surplus for weight gain
                        model.GoalDescription = "Weight Gain (0.5 kg per week)";
                        break;
                    default:
                        model.DailyCalories = model.TDEE;
                        model.GoalDescription = "Maintain Current Weight";
                        break;
                }

                // Calculate macros (40% Carbs, 30% Protein, 30% Fat)
                model.ProteinGrams = (model.DailyCalories * 0.30) / 4; // 4 calories per gram
                model.CarbsGrams = (model.DailyCalories * 0.40) / 4;
                model.FatGrams = (model.DailyCalories * 0.30) / 9; // 9 calories per gram
            }

            return View(model);
        }
    }
}