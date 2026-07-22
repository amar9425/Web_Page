using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}