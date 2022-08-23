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

    [HttpPost]
    public async Task<ActionResult> Login(LoginViewModel user)
    {
      var response = await AuthorizationHelper.Login(user);
      TokenResponse tr = JsonConvert.DeserializeObject<TokenResponse>(response);
      TokenC.Token = tr.Token;
      TokenC.RefreshToken = tr.RefreshToken;
      return RedirectToAction("Index");
    }
  }
}