using RestSharp;
using Newtonsoft.Json;
using TeamWeekClient.Models;
using TeamWeekClient.ViewModels;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;


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

    private static async Task<bool> RefreshToken()
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest("authmanagement/refreshtoken", Method.POST);
      TokenRequest tr = new TokenRequest(TokenC.Token, TokenC.RefreshToken);
      var serializedTR = JsonConvert.SerializeObject(tr);
      request.AddJsonBody(serializedTR);
      var response = await client.ExecuteTaskAsync(request);
      TokenResponse tResponse = JsonConvert.DeserializeObject<TokenResponse>(response.Content);
      TokenC.Token = tResponse.Token;
      TokenC.RefreshToken = tResponse.RefreshToken;
      return response.IsSuccessful;
    }
  }
}