using Microsoft.AspNetCore.Mvc;

namespace FirstProjectDemo.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
