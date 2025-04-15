using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace UntappedAPI.Models.Untapped
{

    public class Profile
    {
        //[JsonProperty("ProfileId")]
        public required string ProfileId { get; set; }

        public required string PlayerName { get; set; }
        public required Ranks Ranks { get; set; }    
        public  MatchHistoryVisibility MatchHistoryVisibility { get; set; }
        public  ReplayVisibility ReplayVisibility { get; set; }


       
    }
    public class Ranks
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public Ranked1v1 Ranked1v1 { get; set; }
    }


    public class Ranked1v1
    {

        public Guid Id { get; init; } = Guid.NewGuid();
        public Vanguard Vanguard { get; set; }
        public Infernals Infernals { get; set; }
        public Celestials Celestials { get; set; }
    }

    public class Vanguard
    {
        public Guid Id { get; init; } = Guid.NewGuid();
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
        public Guid Id { get; init; } = Guid.NewGuid();
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
        public Guid Id { get; init; } = Guid.NewGuid();
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
        public Guid Id { get; init; } = Guid.NewGuid();
        public bool RANKED_1V1 { get; set; }
    }

    public class ReplayVisibility
    {
        public Guid Id { get; init; } = Guid.NewGuid();
        public bool RANKED_1V1 { get; set; }
    }
}
