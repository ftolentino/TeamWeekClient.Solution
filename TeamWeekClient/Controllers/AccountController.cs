using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Mvc;
using TeamWeekClient.Models;
using TeamWeekClient.ViewModels;
using Microsoft.AspNetCore.Identity;
using RestSharp;
// using System.Text.Json;


namespace TeamWeekClient.Controllers
{
  public class AccountController : Controller
  {

    public ActionResult Index()
    {
      if (TokenC.Token != null)
      {
        ViewBag.Token = TokenC.Token;
        ViewBag.RefreshToken = TokenC.RefreshToken;
      }
      return View();
    }

    public ActionResult Login()
    {
      return View();
    }

    // [HttpPost]
    // public async Task<ActionResult> Login(AppUser appUser)
    // {
    //   var response = await User.Login(appUser);
    //   TokenResponse tr = JsonConvert.DeserializeObject<TokenResponse>(response);
    //   TokenC.Token = tr.Token;
    //   TokenC.RefreshToken = tr.RefreshToken;
    //   return RedirectToAction("Index");
    // }

    // public ActionResult Register()
    // {
    //   return View();
    // }

    // [HttpPost]
    // public async Task<IActionResult> Register(AppUser appUser)
    // {
    //   var response = await AppUser.Post(appUser);
    //   JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response);
    //   AppUser.Token = ((string)jsonResponse["token"]); 
    //   ViewBag.ResultBody = AppUser.Token;     
    //   return View("Index", "Home");
    // }

    [HttpPost]
    public async Task<IActionResult> Register(AppUser user)
    {
      var response = await AppUser.Post(user);
      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response);
      AppUser.Token = ((string)jsonResponse["token"]); 
      ViewBag.ResultBody = AppUser.Token;     
      return View();
    }

    

  }
}