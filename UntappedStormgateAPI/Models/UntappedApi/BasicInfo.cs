namespace UntappedAPI.Models.Untapped
{

    public class BasicInfo
    {
        public string PlayerName { get; set; }
        public string ProfileId { get; set; }
        public Ranks Ranks { get; set; }    
        public MatchHistoryVisibility MatchHistoryVisibility { get; set; }
        public ReplayVisibility ReplayVisibility { get; set; }
    }

    public class Ranks
    {
        public Ranked1v1 Ranked1v1 { get; set; }
    }

    public class Ranked1v1
    {
        public Vanguard Vanguard { get; set; }
        public Infernals Infernals { get; set; }
        public Celestials Celestials { get; set; }
    }

    public class Vanguard
    {
        public string League { get; set; }
        public int Losses { get; set; }
        public int Mmr { get; set; }
        public int Points { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Ties { get; set; }
        public int Wins { get; set; }
    }

    public class Infernals
    {
        public string League { get; set; }
        public int Losses { get; set; }
        public int Mmr { get; set; }
        public int Points { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public object Ties { get; set; }
        public int Wins { get; set; }
    }

    public class Celestials
    {
        public string League { get; set; }
        public int Losses { get; set; }
        public int Mmr { get; set; }
        public int Points { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public object Ties { get; set; }
        public int Wins { get; set; }
    }

    public class MatchHistoryVisibility
    {
        public bool RANKED_1V1 { get; set; }
    }

    public class ReplayVisibility
    {
        public bool RANKED_1V1 { get; set; }
    }
}
