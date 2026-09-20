using FitnessTracker.Models;
using Microsoft.AspNetCore.Mvc;

namespace FitnessTracker.Controllers
{
    public class AccountController : Controller
    {
        // Register GET
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        // Register POST
        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                // Check if email already exists
                if (DataStore.GetUserByEmail(user.Email) != null)
                {
                    ModelState.AddModelError("Email", "Email is already registered");
                    return View(user);
                }

                DataStore.AddUser(user);
                SessionHelper.SetUser(HttpContext.Session, user);
                TempData["Success"] = "Registration successful!";
                return RedirectToAction("Index", "Home");
            }

            return View(user);
        }

        // Login GET
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        // Login POST
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = DataStore.GetUserByEmail(email);

            if (user != null && user.Password == password)
            {
                SessionHelper.SetUser(HttpContext.Session, user);
                TempData["Success"] = $"Welcome back, {user.FullName}!";
                return RedirectToAction("Index", "Dashboard");
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        // Logout
        public IActionResult Logout()
        {
            SessionHelper.ClearSession(HttpContext.Session);
            TempData["Success"] = "You have been logged out";
            return RedirectToAction("Index", "Home");
        }

        // Profile
        public IActionResult Profile()
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Login");
            }

            var user = SessionHelper.GetUser(HttpContext.Session);
            return View(user);
        }

        // Edit Profile GET
        [HttpGet]
        public IActionResult EditProfile()
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Login");
            }

            var user = SessionHelper.GetUser(HttpContext.Session);
            return View(user);
        }

        // Edit Profile POST
        [HttpPost]
        public IActionResult EditProfile(User user)
        {
            if (!SessionHelper.IsLoggedIn(HttpContext.Session))
            {
                return RedirectToAction("Login");
            }

            if (ModelState.IsValid)
            {
                var currentUser = SessionHelper.GetUser(HttpContext.Session);
                user.Id = currentUser.Id;
                user.CreatedAt = currentUser.CreatedAt;

                DataStore.UpdateUser(user);
                SessionHelper.SetUser(HttpContext.Session, user);
                TempData["Success"] = "Profile updated successfully!";
                return RedirectToAction("Profile");
            }

            return View(user);
        }
    }
}