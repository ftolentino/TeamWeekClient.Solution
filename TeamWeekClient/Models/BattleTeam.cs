using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
  public class BattleTeam
  {
    public int id { get; set; }
    public string name { get; set; }
    public List<Animal> animals { get; set; }
  }
}