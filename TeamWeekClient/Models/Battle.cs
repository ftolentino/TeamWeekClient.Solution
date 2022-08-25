using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TeamWeekClient.Models
{
  public class Battle
  {
    public int outcome { get; set; }
    public BattleTeam team1 { get; set; }
    public BattleTeam team2 { get; set; }
  }
}
  