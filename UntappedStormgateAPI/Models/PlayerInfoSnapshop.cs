using System.Diagnostics;
using UntappedAPI.Models.Untapped;
using UntappedAPI.Models.Untapped.PlayerStats;

namespace UntappedAPI.Models
{

    [DebuggerDisplay("Id {ProfileId}, Name {PlayerName}")]
    public class PlayerInfoSnapshot
    {

        //TODO: ProfileId and PlayerName is dublicate in BasicInfo
        public required string ProfileId { get; set; }
        public required string PlayerName { get; set; }
        public required DateTime LastSnapshot { get; set; }

        //From DTOs
        public required BasicInfo PlayerBasicInfo { get; set; }
        public CuratedPlayerStats? CuratedPlayerStats { get; set; }



    }
}
