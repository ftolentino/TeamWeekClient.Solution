using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
  public class AnimalTeam
  {
    public int AnimalTeamId { get; set; }
    public int AnimalId { get; set; }
    public int TeamId { get; set; }

    public static List<AnimalTeam> GetAnimalTeams(int teamId)
    {
      var apiCallTask = ApiHelper.GetAnimalTeams(teamId);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<AnimalTeam> animalList = JsonConvert.DeserializeObject<List<AnimalTeam>>(jsonResponse.ToString());

      return animalList;
    }

    // public static void DeleteAnimalTeam(int animalTeamId)
    // {
    //   var apiCallTask = ApiHelper.DeleteAnimalTeam(animalTeamId);
    // }
  }
}