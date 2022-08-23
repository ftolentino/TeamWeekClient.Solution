using RestSharp;
using TeamWeekClient.Models;
using TeamWeekClient.ViewModels;

namespace TeamWeekClient.Models
{
  public class AuthorizationHelper
  {
    // public static async Task<string> Get(string requestType)
    // {
    //   RestClient client = new RestClient("http://localhost:5000/api");
    //   RestRequest request = new RestRequest("authmanagement", Method.GET);
    //   var response = await client.ExecuteTaskAsync(request);
    //   return response.Content;
    // }

    public static async Task<string> Register(RegisterViewModel newUser)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest("authmanagement/login", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newUser);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Login(LoginViewModel user)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest("authmanagement/login", Method.POST);
      request.AddJsonBody(user);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  }
}