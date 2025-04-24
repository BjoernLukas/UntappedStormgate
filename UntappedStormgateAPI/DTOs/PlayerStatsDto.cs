namespace UntappedAPI.DTOs.PlayerStatsDto
{


    public class PlayerStatsDto
    {
        public _13 _13 { get; set; }
        public All all { get; set; }
    }

    public class _13
    {
        public Vanguard vanguard { get; set; }
    }

    public class Vanguard
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration outcomes_by_duration { get; set; }
        public Outcomes_By_Opponent[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map outcomes_by_map { get; set; }
        public Summary summary { get; set; }
    }

    public class Outcomes_By_Duration
    {
        public Vanguard1[] vanguard { get; set; }
        public Infernal[] infernals { get; set; }
    }

    public class Vanguard1
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernal
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race
    {
        public Vanguard2 vanguard { get; set; }
        public Infernals infernals { get; set; }
    }

    public class Vanguard2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernals
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map
    {
        public Secludedgrovev2 SecludedGroveV2 { get; set; }
        public Losthope LostHope { get; set; }
        public Furiousresolve FuriousResolve { get; set; }
        public Ruination Ruination { get; set; }
        public Boneyard Boneyard { get; set; }
        public Isleofdread IsleOfDread { get; set; }
        public Brokencrown BrokenCrown { get; set; }
        public Titanscausewayv2 TitansCausewayV2 { get; set; }
    }

    public class Secludedgrovev2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Losthope
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

    public class Ruination
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Boneyard
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Isleofdread
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Brokencrown
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Titanscausewayv2
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

    public class Outcomes_By_Opponent
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
        public Vanguard4[] vanguard { get; set; }
        public Infernal1[] infernals { get; set; }
    }

    public class Vanguard4
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernal1
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race1
    {
        public Vanguard5 vanguard { get; set; }
        public Infernals1 infernals { get; set; }
    }

    public class Vanguard5
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernals1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map1
    {
        public Secludedgrovev21 SecludedGroveV2 { get; set; }
        public Losthope1 LostHope { get; set; }
        public Furiousresolve1 FuriousResolve { get; set; }
        public Ruination1 Ruination { get; set; }
        public Boneyard1 Boneyard { get; set; }
        public Isleofdread1 IsleOfDread { get; set; }
        public Brokencrown1 BrokenCrown { get; set; }
        public Titanscausewayv21 TitansCausewayV2 { get; set; }
    }

    public class Secludedgrovev21
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Losthope1
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

    public class Ruination1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Boneyard1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Isleofdread1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Brokencrown1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Titanscausewayv21
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
