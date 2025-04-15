

namespace UntappedAPI.Models.Untapped.PlayerStats
{
    public class CuratedStats
    {
        public int Id { get; init; }
        public All All { get; set; }
    }
    public class All
    {
        public int Id { get; init; }
        public VanguardPlayerStats Vanguard { get; set; }

        public InfernalsPlayerStats Infernals { get; set; }

        public CelestialsPlayerStats Celestials { get; set; }
    }

    public class VanguardPlayerStats
    {
        public int Id { get; init; }
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

    }

    public class InfernalsPlayerStats
    {
        public int Id { get; init; }
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

    }

    public class CelestialsPlayerStats
    {
        public int Id { get; init; }
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

    }

    public class Outcomes_By_Opponent
    {
        public int Id { get; init; }
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }



}
