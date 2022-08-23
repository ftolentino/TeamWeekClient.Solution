using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
  public class User
  {
    public string Email { get; set; }
    public string Password { get; set; }
    public User(string email, string password)
    {
      Email = email;
      Password = password;
    }
  }
}