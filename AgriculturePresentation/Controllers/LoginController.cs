using Microsoft.AspNetCore.Mvc;

namespace AgriculturePresentation.Controllers;

public class LoginController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}