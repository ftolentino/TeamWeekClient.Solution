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
    private static Battle _battle;
    public IActionResult Index(int id)
    {
      _battle = Team.Battle(id);
      return View(_battle);
    }

    public IActionResult Winner()
    {
      return View(_battle);
    }
  }
}
