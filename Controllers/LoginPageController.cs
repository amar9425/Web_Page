using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using System.Linq;

namespace WebApplication.Controllers
{
    public class LoginPageController : Controller
    {
        private readonly AppDbContext _context;

        public LoginPageController(AppDbContext context)
        {
            _context = context;
        }

        // Login Page
        public IActionResult Index()
        {
            return View();
        }

        // Login
        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            var user = _context.Users.FirstOrDefault(x =>
                x.Email == email && x.Password == password);

            if (user != null)
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
            User user = new User()
            {
                FullName = name,
                Email = email,
                Password = password,
                confirmPassword = password
            };

            _context.Users.Add(user);
            _context.SaveChanges();

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
            var user = _context.Users.FirstOrDefault(x => x.Email == email);

            if (user != null)
            {
                ViewBag.Message = "Your Password is : " + user.Password;
            }
            else
            {
                ViewBag.Message = "Email not found.";
            }

            return View();
        }
    }
}