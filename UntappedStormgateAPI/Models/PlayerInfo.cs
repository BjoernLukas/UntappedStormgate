namespace UntappedAPI.Models
{   

    public class PlayerInfo
    {
        public Ranks Ranks { get; set; }
        public string PlayerName { get; set; }
        public string ProfileId { get; set; }
        public Matchhistoryvisibility MatchHistoryVisibility { get; set; }
        public Replayvisibility ReplayVisibility { get; set; }
    }

    public class Ranks
    {
        public Ranked_1V1 ranked_1v1 { get; set; }
    }

    public class Ranked_1V1
    {
        public Vanguard vanguard { get; set; }
        public Infernals infernals { get; set; }
        public Celestials celestials { get; set; }
    }

    public class Vanguard
    {
        public string league { get; set; }
        public int losses { get; set; }
        public int mmr { get; set; }
        public int points { get; set; }
        public int season { get; set; }
        public int tier { get; set; }
        public int ties { get; set; }
        public int wins { get; set; }
    }

    public class Infernals
    {
        public string league { get; set; }
        public int losses { get; set; }
        public int mmr { get; set; }
        public int points { get; set; }
        public int season { get; set; }
        public int tier { get; set; }
        public object ties { get; set; }
        public int wins { get; set; }
    }

    public class Celestials
    {
        public string league { get; set; }
        public int losses { get; set; }
        public int mmr { get; set; }
        public int points { get; set; }
        public int season { get; set; }
        public int tier { get; set; }
        public object ties { get; set; }
        public int wins { get; set; }
    }

    public class Matchhistoryvisibility
    {
        public bool RANKED_1V1 { get; set; }
    }

    public class Replayvisibility
    {
        public bool RANKED_1V1 { get; set; }
    }

}
