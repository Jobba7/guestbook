using Microsoft.AspNetCore.Mvc;

namespace Guestbook.Controllers;

public class HomeController : Controller
{
  public IActionResult Index()
  {
    return View();
  }
}
