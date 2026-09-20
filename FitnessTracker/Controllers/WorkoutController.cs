using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class WorkoutController : Controller
    {
        // Check login before every action
        private bool CheckLogin()
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                TempData["Error"] = "Please login to access workouts";
                return false;
            }
            return true;
        }

        // List all workouts
        public IActionResult Index()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var workouts = SessionHelper.GetWorkouts(HttpContext.Session);
            return View(workouts);
        }

        // Add Workout GET
        [HttpGet]
        public IActionResult Add()
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");
            return View();
        }

        // Add Workout POST
        [HttpPost]
        public IActionResult Add(Workout workout)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                SessionHelper.AddWorkout(HttpContext.Session, workout);
                TempData["Success"] = "Workout added successfully!";
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // Edit Workout GET
        [HttpGet]
        public IActionResult Edit(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var workout = SessionHelper.GetWorkoutById(HttpContext.Session, id);
            if (workout == null)
            {
                TempData["Error"] = "Workout not found";
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // Edit Workout POST
        [HttpPost]
        public IActionResult Edit(Workout workout)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            if (ModelState.IsValid)
            {
                SessionHelper.UpdateWorkout(HttpContext.Session, workout);
                TempData["Success"] = "Workout updated successfully!";
                return RedirectToAction("Index");
            }
            return View(workout);
        }

        // Delete Workout
        public IActionResult Delete(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            SessionHelper.DeleteWorkout(HttpContext.Session, id);
            TempData["Success"] = "Workout deleted successfully!";
            return RedirectToAction("Index");
        }

        // View Workout Details
        public IActionResult Details(int id)
        {
            if (!CheckLogin()) return RedirectToAction("Login", "Account");

            var workout = SessionHelper.GetWorkoutById(HttpContext.Session, id);
            if (workout == null)
            {
                TempData["Error"] = "Workout not found";
                return RedirectToAction("Index");
            }
            return View(workout);
        }
    }
}