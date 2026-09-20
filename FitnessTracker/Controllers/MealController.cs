using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class MealController : Controller
    {
        // Check login before every action
        private bool CheckLogin()
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                TempData["Error"] = "Please login to access meals";
                return false;
            }
            return true;
        }

        // List all meals
        public IActionResult Index()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var meals = SessionHelper.GetMeals(HttpContext.Session);
            return View(meals);
        }

        // Add Meal GET
        [HttpGet]
        public IActionResult Add()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");
            return View();
        }

        // Add Meal POST
        [HttpPost]
        public IActionResult Add(Meal meal)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                SessionHelper.AddMeal(HttpContext.Session, meal);
                TempData["Success"] = "Meal added successfully!";
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // Edit Meal GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var meal = SessionHelper.GetMealById(HttpContext.Session, id);
            if (meal == null)
            {
                TempData["Error"] = "Meal not found";
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // Edit Meal POST
        [HttpPost]
        public IActionResult Edit(Meal meal)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                SessionHelper.UpdateMeal(HttpContext.Session, meal);
                TempData["Success"] = "Meal updated successfully!";
                return RedirectToAction("Index");
            }
            return View(meal);
        }

        // Delete Meal
        public IActionResult Delete(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            SessionHelper.DeleteMeal(HttpContext.Session, id);
            TempData["Success"] = "Meal deleted successfully!";
            return RedirectToAction("Index");
        }

        // View Meal Details
        public IActionResult Details(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var meal = SessionHelper.GetMealById(HttpContext.Session, id);
            if (meal == null)
            {
                TempData["Error"] = "Meal not found";
                return RedirectToAction("Index");
            }
            return View(meal);
        }
    }
}