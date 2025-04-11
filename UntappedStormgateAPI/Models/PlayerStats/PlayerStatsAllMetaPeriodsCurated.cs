using UntappedAPI.Models.PlayerStats.RawPlayerStats;

namespace UntappedAPI.Models.PlayerStats.AllMetaPeriods
{
    public class PlayerStatsAllMetaPeriodsCurated
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
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

    }

    public class InfernalsPlayerStats
    {
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

    }

    public class CelestialsPlayerStats
    {
        public int[] Recent_mmr_history { get; set; }

        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }

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
