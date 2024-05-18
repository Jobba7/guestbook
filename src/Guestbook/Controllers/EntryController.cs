using Guestbook.Models.Entries;
using Guestbook.Services;

using Microsoft.AspNetCore.Mvc;

namespace Guestbook.Controllers;
public class EntryController(IEntryService service) : Controller
{
  public IActionResult Index()
  {
    var entries = service.GetEntries();

    return View(entries);
  }

  public IActionResult Create()
  {
    return View();
  }

  [HttpPost]
  public IActionResult Create(CreateEntryViewModel model)
  {
    if (!ModelState.IsValid)
    {
      return View(model);
    }

    service.CreateEntry(model.Content, Guid.Empty);

    return RedirectToAction(nameof(Index));
  }
}
