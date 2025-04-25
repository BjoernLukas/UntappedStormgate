using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using UntappedAPI.DTOs;
using UntappedAPI.DTOs.PlayerLookUpDto;


namespace UntappedAPI.Models
{

    [DebuggerDisplay("Name {PlayerName}")]
    public class PlayerSnapshot
    {

        //For now I try using the ProfileId as the key
        //public required Guid PlayerSnapshotId { get; init; } = Guid.NewGuid();

        //Meta data
        public required DateTime LastSnapshot { get; set; }
        public required InfoRichness InfoRichness { get; set; }


        //Light_NameAndIdKnow, that can be gathered by resent game history
        [Key]
        public required string ProfileId { get; init; }
        public required string PlayerName { get; set; }
        

        //InfoRichness Medium_Lookup
        public bool? MatchHistoryVisibility { get; set; }
        public bool? ReplayVisibility { get; set; }


        //FullHistoryPublic




    }
    public enum InfoRichness
    {
        Light_NameAndIdKnow,
        Medium_Lookup,
        Full_PublicHistory
    }
}
