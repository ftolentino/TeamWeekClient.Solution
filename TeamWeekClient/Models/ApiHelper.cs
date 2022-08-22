using System.Threading.Tasks;
using RestSharp;

namespace TeamWeekClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }
  
    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post (string newAnimal)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);   
    }

    public static async Task Put(int id, string newAnimal)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newAnimal);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}