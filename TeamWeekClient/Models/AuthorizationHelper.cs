using RestSharp;
using Newtonsoft.Json;


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

    public static async Task<string> Register(string appUser)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest("authmanagement/register", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(appUser);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> Login(string appUser)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest("authmanagement/login", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(appUser);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    
  }
}