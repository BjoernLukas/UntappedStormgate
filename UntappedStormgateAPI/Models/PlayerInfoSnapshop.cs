using UntappedAPI.Models.Untapped;
using UntappedAPI.Models.Untapped.PlayerStats;

namespace UntappedAPI.Models
{
    public class PlayerInfoSnapshot
    {
        public required DateTime LastSnapshot { get; set; }

        public required PlayerBasicInfo PlayerBasicInfo { get; set; }

        public required PlayerStatsAllMetaPeriodsCurated PlayerStatsAllMetaPeriodsCurated { get; set; }



    }
}
