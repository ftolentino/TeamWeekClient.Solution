using Newtonsoft.Json;

namespace TeamWeekClient.Models
{
  public class AppUser 
  {
    public string Name { get; set; } = default!;
    public string Email { get; set; } = default!;
    public string Password { get; set; } = default!;
    public static string Token { get; set; } = default!;
    public static string RefreshToken { get; set; } = default!;

    public static Task<string> Post(AppUser appUser)
    {
      string jsonUser = JsonConvert.SerializeObject(appUser);
      var apiCallTask = AuthorizationHelper.Register(jsonUser);
      return apiCallTask;
    }


    public static Task<string> Login(AppUser appUser)
    {
      string jsonUser = JsonConvert.SerializeObject(appUser);
      var apiCallTask = AuthorizationHelper.Login(jsonUser);
      return apiCallTask;
    }
  }
}