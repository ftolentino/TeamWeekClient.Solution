using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamWeekClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Controllers
{
  public class TeamsController : Controller
  {
    public IActionResult Index()
    {
      string id = TokenC.Email;
      var userTeam = Team.GetUserTeams(id);
      return View(userTeam);
    }

    [HttpPost]
    public IActionResult Index(Team team)
    {
      Team.Post(team);
      return RedirectToAction("Index", "Teams");
    }


    public IActionResult Create()
    {
      return View();
    }
    
    [HttpPost]
    public IActionResult Create(Team team)
    {
      Team.Post(team);
      return RedirectToAction("Index");
    }
    public IActionResult Edit(int id)
    {
      var team = Team.GetDetails(id);
      return View(team);
    }

    public IActionResult Details(int id)
    {
      var team = Team.GetDetails(id);
      return View(team);
    }

    [HttpPost]
    public IActionResult Details(int id, Team team)
    {
      team.TeamId = id;
      Team.Put(team);
      return RedirectToAction("Details", id);
    }

    public IActionResult Delete(int id)
    {
      Team.Delete(id);
      return RedirectToAction("Index");
    }
  }
}