using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TeamWeekClient.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Dynamic;

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
      ViewBag.Animals = Animal.GetTeamAnimals(id);
      ViewBag.AllAnimals = Animal.GetAnimals();
      return View(team);
    }

    [HttpPost]
    public IActionResult Edit(int teamId, int animal)
    {
      var team = Team.GetDetails(teamId);
      ViewBag.Animals = Animal.GetTeamAnimals(teamId);
      ViewBag.AllAnimals = Animal.GetAnimals();
      
      return RedirectToAction("Edit");
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

    [HttpPost]
    public IActionResult AddAnimalToTeam(int teamId, int animalId)
    {
      Team.PostAnimalToTeam(teamId, animalId);
      return RedirectToAction("Edit", new { id = teamId});
    }

    [HttpPost]
    public IActionResult DeleteAnimalFromTeam(int teamId, int animalId)
    {
      Team.DeleteAnimalFromTeam(teamId, animalId);
      return RedirectToAction("Edit", new { id = teamId});
    }
  }
}