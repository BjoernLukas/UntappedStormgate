namespace UntappedAPI.DataUtility.RawPlayerStats
{

    public class RawPlayerStats
    {
        public _12 _12 { get; set; }
        public All all { get; set; }
    }

    public class _12
    {
        public Vanguard vanguard { get; set; }
    }

    public class Vanguard
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration outcomes_by_duration { get; set; }
        public Vanguard_Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map outcomes_by_map { get; set; }
        public Summary summary { get; set; }
    }

    public class Outcomes_By_Duration
    {
        public Celestial[] celestials { get; set; }
        public Vanguard1[] vanguard { get; set; }
    }

    public class Celestial
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard1
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race
    {
        public Celestials celestials { get; set; }
        public Vanguard2 vanguard { get; set; }
    }

    public class Celestials
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map
    {
        public Brokencrown BrokenCrown { get; set; }
        public Furiousresolve FuriousResolve { get; set; }
    }

    public class Brokencrown
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Furiousresolve
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Summary
    {
        public int points { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string league { get; set; }
        public int tier { get; set; }
        public int mmr { get; set; }
    }

    public class Vanguard_Outcomes_By_Opponent
    {
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class All
    {
        public Vanguard3 vanguard { get; set; }
    }

    public class Vanguard3
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration1 outcomes_by_duration { get; set; }
        public Outcomes_By_Opponent1[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race1 outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map1 outcomes_by_map { get; set; }
        public Summary1 summary { get; set; }
    }

    public class Outcomes_By_Duration1
    {
        public Celestial1[] celestials { get; set; }
        public Vanguard4[] vanguard { get; set; }
    }

    public class Celestial1
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard4
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race1
    {
        public Celestials1 celestials { get; set; }
        public Vanguard5 vanguard { get; set; }
    }

    public class Celestials1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard5
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map1
    {
        public Brokencrown1 BrokenCrown { get; set; }
        public Furiousresolve1 FuriousResolve { get; set; }
    }

    public class Brokencrown1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Furiousresolve1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Summary1
    {
        public int points { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string league { get; set; }
        public int tier { get; set; }
        public int mmr { get; set; }
    }

    public class Outcomes_By_Opponent1
    {
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }



}
