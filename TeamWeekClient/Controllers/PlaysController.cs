using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamWeekClient.Models;

namespace TeamWeekClient.Controllers
{
  public class PlaysController : Controller
  {
    public IActionResult Index()
    {
      var battle = Team.Battle(2);
      return View(battle);
    }
  }
}
