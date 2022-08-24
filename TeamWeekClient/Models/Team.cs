using System.Collections.Generic;
using System;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
  public class Team
  {
    public int TeamId { get; set; }
    public string UserId { get; set; } = default!;
    public string Name { get; set; } = default!;
    public int Wins { get; set; }
    public int Losses { get; set; }
    
    public static List<Team> GetTeams()
    {
      var apiCallTask = ApiHelper.GetAllTeams();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Team> teamList = JsonConvert.DeserializeObject<List<Team>>(jsonResponse.ToString());

      return teamList;
    }

    public static List<Team> GetUserTeams(string id)
    {
      var apiCallTask = ApiHelper.GetUserTeam(id);
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Team> teamList = JsonConvert.DeserializeObject<List<Team>>(jsonResponse.ToString());

      return teamList;
    }

    public static Team GetDetails(int id)
    {
      var apiCallTask = ApiHelper.GetTeam(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Team team  = JsonConvert.DeserializeObject<Team>(jsonResponse.ToString());

      return team;
    }

    public static void Post(Team team)
    {
      string jsonMessage = JsonConvert.SerializeObject(team);
      var apiCallTask = ApiHelper.PostTeam(jsonMessage);
    }

    public static void Put(Team team)
    {
      string jsonMessage = JsonConvert.SerializeObject(team);
      var apiCallTask = ApiHelper.PutTeam(team.TeamId, jsonMessage);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.DeleteTeam(id);
    }
  }
}