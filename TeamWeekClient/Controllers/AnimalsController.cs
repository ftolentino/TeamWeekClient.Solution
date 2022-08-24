using Microsoft.AspNetCore.Mvc;
using TeamWeekClient.Models;

namespace TeamWeekClient.Controllers
{
  public class AnimalsController : Controller
  {
    public IActionResult Index()
    {
      var allAnimals = Animal.GetAnimals();
      return View(allAnimals);
    }
    public IActionResult Details(int id)
    {
      var animal = Animal.GetDetails(id);
      return View(animal);
    }
  }
}
