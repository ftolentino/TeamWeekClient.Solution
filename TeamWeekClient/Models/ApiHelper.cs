using System.Threading.Tasks;
using RestSharp;

namespace TeamWeekClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAllAnimals()
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  
    public static async Task<string> GetAnimal(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetAllTeams()
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  
    public static async Task<string> GetTeam(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task PostTeam (string newTeam)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTeam);
      var response = await client.ExecuteTaskAsync(request);   
    }

    public static async Task PutTeam(int id, string newTeam)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newTeam);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task DeleteTeam(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}