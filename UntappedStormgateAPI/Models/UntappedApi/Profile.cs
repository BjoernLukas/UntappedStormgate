using Newtonsoft.Json;

namespace UntappedAPI.Models.Untapped
{

    public class Profile
    {
        //[JsonProperty("ProfileId")]
        public required string ProfileId { get; set; }

        public required string PlayerName { get; set; }
        public Ranks Ranks { get; set; }    
        public MatchHistoryVisibility MatchHistoryVisibility { get; set; }
        public ReplayVisibility ReplayVisibility { get; set; }
    }

    public class Ranks
    {
        public int Id { get; init; }
        public Ranked1v1 Ranked1v1 { get; set; }
    }

    public class Ranked1v1
    {
        public int Id { get; init; }
        public Vanguard Vanguard { get; set; }
        public Infernals Infernals { get; set; }
        public Celestials Celestials { get; set; }
    }

    public class Vanguard
    {
        public int Id { get; init; }
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
        public int Id { get; init; }
        public string League { get; set; }
        public int Losses { get; set; }
        public int Mmr { get; set; }
        public int Points { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Ties { get; set; }
        public int Wins { get; set; }
    }

    public class Celestials
    {
        public int Id { get; init; }
        public string League { get; set; }
        public int Losses { get; set; }
        public int Mmr { get; set; }
        public int Points { get; set; }
        public int Season { get; set; }
        public int Tier { get; set; }
        public int Ties { get; set; }
        public int Wins { get; set; }
    }

    public class MatchHistoryVisibility
    {
        public int Id { get; init; }
        public bool RANKED_1V1 { get; set; }
    }

    public class ReplayVisibility
    {
        public int Id { get; init; }
        public bool RANKED_1V1 { get; set; }
    }
}
