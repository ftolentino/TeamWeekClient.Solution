using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using TeamWeekClient.Models;
using TeamWeekClient.ViewModels;

namespace TeamWeekClient.Models
{
  public class ApiHelper
  {
    public static async Task<string> GetAllAnimals()
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      // request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetAnimal(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animals/{id}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      // request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task<string> GetTeamAnimals(int tId)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/TeamAnimals/{tId}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await GetTeamAnimals(tId);
        }
      }
      return response.Content;
    }

    public static async Task<string> GetTeam(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await GetTeam(id);
        }
      }
      return response.Content;
    }

    public static async Task<string> GetUserTeam(string id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/Player/{id}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await GetUserTeam(id);
        }
      }
      return response.Content;
    }

    public static async Task PostTeam(string newTeam)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      request.AddJsonBody(newTeam);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await PostTeam(newTeam);
        }
      }
    }

    public static async Task<string> PostAnimalToTeam(int teamId, int animalId)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{teamId}/{animalId}", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await PostAnimalToTeam(teamId, animalId);
        }
      }
      return response.Content;
    }

    public static async Task PutTeam(int id, string newTeam)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + AppUser.Token);
      request.AddJsonBody(newTeam);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await PutTeam(id, newTeam);
        }
      }
    }
    public static async Task DeleteTeam(int id)
    {

      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await DeleteTeam(id);
        }
      }
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

    public static async Task<string> GetBattleResult(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/battle/{id}", Method.GET);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await GetBattleResult(id);
        }
      }
      return response.Content;
    }

    public static async Task<string> GetAnimalTeams(int id)
    {
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"animalteams/{id}", Method.GET);
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await GetAnimalTeams(id);
        }
      }
      return response.Content;
    }

    public static async Task<string> DeleteAnimalTeam(int teamId, int animalId)
    {
      // eventually need to also pass in UserId to confirm that they can delete it
      RestClient client = new RestClient("https://slagapi.azurewebsites.net/api");
      RestRequest request = new RestRequest($"teams/{teamId}/{animalId}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      request.AddHeader("Authorization", "Bearer " + TokenC.Token);
      var response = await client.ExecuteTaskAsync(request);
      if (response.StatusCode == HttpStatusCode.Unauthorized)
      {
        if (await RefreshToken())
        {
          await DeleteAnimalTeam(teamId, animalId);
        }
      }
      return response.Content;
    }
  }
}