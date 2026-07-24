using Microsoft.AspNetCore.Mvc;

namespace WebApplication.Controllers
{
    public class AdminController : Controller
    {
        [HttpGet]
        public IActionResult Dashboard()
        {
            return View();
        }
    }
}