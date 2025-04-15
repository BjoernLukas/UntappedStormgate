

namespace UntappedAPI.Models.Untapped.PlayerStats
{
    public class CuratedStats
    {
        public Guid CuratedStatsId { get; init; } = Guid.NewGuid();
        public All All { get; set; }
    }
    public class All
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public VanguardPlayerStats Vanguard { get; set; }
        public InfernalsPlayerStats Infernals { get; set; }
        public CelestialsPlayerStats Celestials { get; set; }
    }

    public class VanguardPlayerStats
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class InfernalsPlayerStats
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class CelestialsPlayerStats
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public List<int> Recent_mmr_history { get; set; } = new();
        public List<Outcomes_By_Opponent> outcomes_by_opponent { get; set; } = new();
    }

    public class Outcomes_By_Opponent
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }



}
