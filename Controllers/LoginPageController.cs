using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class LoginPageController : Controller
    {
        // Temporary Storage (Without Database)
        private static string savedName = "";
        private static string savedEmail = "";
        private static string savedPassword = "";

        // Login Page
        public IActionResult Index()
        {
            return View();
        }

        // Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Default Admin Login
            if (email == "admin@gmail.com" && password == "12345")
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            // Registered User Login
            if (email == savedEmail && password == savedPassword)
            {
                return RedirectToAction("Dashboard", "Admin");
            }

            ViewBag.Message = "Invalid Email or Password";
            return View("Index");
        }

        // Register Page
        public IActionResult Register()
        {
            return View();
        }

        // Register
        [HttpPost]
        public IActionResult Register(string name, string email, string password)
        {
            savedName = name;
            savedEmail = email;
            savedPassword = password;

            TempData["Success"] = "Registration Successful. Please Login.";

            return RedirectToAction("Index");
        }

        // Forgot Password Page
        public IActionResult ForgotPassword()
        {
            return View();
        }

        // Forgot Password
        [HttpPost]
        public IActionResult ForgotPassword(string email)
        {
            if (email == savedEmail)
            {
                ViewBag.Message = "Your Password is : " + savedPassword;
            }
            else
            {
                ViewBag.Message = "Email not found.";
            }

            return View();
        }
    }
}