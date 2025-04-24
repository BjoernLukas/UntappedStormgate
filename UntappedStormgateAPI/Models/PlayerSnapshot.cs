using System.Diagnostics;
using UntappedAPI.DTOs;


namespace UntappedAPI.Models
{

    [DebuggerDisplay("Id {ProfileId}, Name {PlayerName}")]
    public class PlayerSnapshot
    {

        //Remark PlayerSnapshotId and PlayerName is duplicated in Profile
        public required string PlayerSnapshotId { get; set; }
        public required string PlayerName { get; set; }
        public required DateTime LastSnapshot { get; set; }

        //From DTOs
        //public required Profile Profile { get; set; }
        //public PlayerStatsCuratedStatsDto? CuratedStats { get; set; }



    }
}
