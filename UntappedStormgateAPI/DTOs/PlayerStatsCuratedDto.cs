namespace UntappedAPI.DTOs.PlayerStatsCuratedStatsDto
{
    public class PlayerStatsCuratedStatsDto
    {        
        public All All { get; set; }
    }
    public class All
    {     
        public VanguardPlayerStats Vanguard { get; set; }
        public InfernalsPlayerStats Infernals { get; set; }
        public CelestialsPlayerStats Celestials { get; set; }
    }

    public class VanguardPlayerStats
    {     
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class InfernalsPlayerStats
    {
       
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class CelestialsPlayerStats
    {
     
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class Outcomes_By_Opponent
    {
       
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }



}
