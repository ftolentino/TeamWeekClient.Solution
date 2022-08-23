using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using TeamWeekClient.Models;
using TeamWeekClient.ViewModels;



namespace TeamWeekClient.Models
{
  public class AppUser
  {
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public static string Token { get; set; } = default!;
    // public AppUser(string email, string password)
    // {
    //   Email = email;
    //   Password = password;
    // }

    public static Task<string> Post(AppUser appUser)
    {
      string jsonUser = JsonConvert.SerializeObject(appUser);
      var apiCallTask = AuthorizationHelper.Register(jsonUser);
      return apiCallTask;
    }

    // public static Task<string> Login(AppUser AppUser)
    // {
    //   string jsonUser = JsonConvert.SerializeObject(AppUser);
    //   var apiCallTask = AuthorizationHelper.Login(jsonUser);
    //   return apiCallTask;
    // }
  }
}