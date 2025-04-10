using Newtonsoft.Json;

namespace UntappedAPI.Models
{
    public class PlayerStats
    {
    }


    public class Rootobject
    {
        public _9 _9 { get; set; }
        public _10 _10 { get; set; }
        public _11 _11 { get; set; }
        public _12 _12 { get; set; }
        public All all { get; set; }
    }

    public class _9
    {
        public Vanguard vanguard { get; set; }
    }

    [JsonObject("Vanguard")]
    public class VanguardStats
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
        public Celestial[] celestials { get; set; }
        public Infernal[] infernals { get; set; }
    }

    public class Vanguard1
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestial
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
        public Celestials celestials { get; set; }
        public Infernals infernals { get; set; }
    }

    public class Vanguard2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    [JsonObject("Celestials")]
    public class CelestialsStats
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }


    [JsonObject("Infernals")]
    public class InfernalsStats
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map
    {
        public Isleofdread IsleOfDread { get; set; }
        public Titanscausewayv2 TitansCausewayV2 { get; set; }
        public Brokencrown BrokenCrown { get; set; }
        public Ruination Ruination { get; set; }
        public Secludedgrovev2 SecludedGroveV2 { get; set; }
        public Losthope LostHope { get; set; }
        public Boneyard Boneyard { get; set; }
        public Furiousresolve FuriousResolve { get; set; }
    }

    public class Isleofdread
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

    public class Brokencrown
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

    public class Boneyard
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

    public class Outcomes_By_Opponent
    {
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class _10
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
        public Infernal1[] infernals { get; set; }
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

    public class Infernal1
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
        public Infernals1 infernals { get; set; }
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

    public class Infernals1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map1
    {
        public Ruination1 Ruination { get; set; }
        public Furiousresolve1 FuriousResolve { get; set; }
        public Losthope1 LostHope { get; set; }
        public Secludedgrovev21 SecludedGroveV2 { get; set; }
        public Boneyard1 Boneyard { get; set; }
        public Isleofdread1 IsleOfDread { get; set; }
        public Brokencrown1 BrokenCrown { get; set; }
        public Titanscausewayv21 TitansCausewayV2 { get; set; }
    }

    public class Ruination1
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

    public class Losthope1
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Secludedgrovev21
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

    public class _11
    {
        public Vanguard6 vanguard { get; set; }
    }

    public class Vanguard6
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration2 outcomes_by_duration { get; set; }
        public Outcomes_By_Opponent2[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race2 outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map2 outcomes_by_map { get; set; }
        public Summary2 summary { get; set; }
    }

    public class Outcomes_By_Duration2
    {
        public Vanguard7[] vanguard { get; set; }
        public Infernal2[] infernals { get; set; }
        public Celestial2[] celestials { get; set; }
    }

    public class Vanguard7
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernal2
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestial2
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race2
    {
        public Vanguard8 vanguard { get; set; }
        public Infernals2 infernals { get; set; }
        public Celestials2 celestials { get; set; }
    }

    public class Vanguard8
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Infernals2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestials2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map2
    {
        public Secludedgrovev22 SecludedGroveV2 { get; set; }
        public Brokencrown2 BrokenCrown { get; set; }
        public Furiousresolve2 FuriousResolve { get; set; }
        public Titanscausewayv22 TitansCausewayV2 { get; set; }
        public Losthope2 LostHope { get; set; }
        public Isleofdread2 IsleOfDread { get; set; }
        public Ruination2 Ruination { get; set; }
        public Boneyard2 Boneyard { get; set; }
    }

    public class Secludedgrovev22
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Brokencrown2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Furiousresolve2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Titanscausewayv22
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Losthope2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Isleofdread2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Ruination2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Boneyard2
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Summary2
    {
        public int points { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string league { get; set; }
        public int tier { get; set; }
        public int mmr { get; set; }
    }

    public class Outcomes_By_Opponent2
    {
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class _12
    {
        public Vanguard9 vanguard { get; set; }
    }

    public class Vanguard9
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration3 outcomes_by_duration { get; set; }
        public Outcomes_By_Opponent3[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race3 outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map3 outcomes_by_map { get; set; }
        public Summary3 summary { get; set; }
    }

    public class Outcomes_By_Duration3
    {
        public Infernal3[] infernals { get; set; }
        public Celestial3[] celestials { get; set; }
        public Vanguard10[] vanguard { get; set; }
    }

    public class Infernal3
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestial3
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard10
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race3
    {
        public Infernals3 infernals { get; set; }
        public Celestials3 celestials { get; set; }
        public Vanguard11 vanguard { get; set; }
    }

    public class Infernals3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestials3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard11
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map3
    {
        public Boneyard3 Boneyard { get; set; }
        public Ruination3 Ruination { get; set; }
        public Losthope3 LostHope { get; set; }
        public Furiousresolve3 FuriousResolve { get; set; }
        public Isleofdread3 IsleOfDread { get; set; }
        public Titanscausewayv23 TitansCausewayV2 { get; set; }
        public Secludedgrovev23 SecludedGroveV2 { get; set; }
        public Brokencrown3 BrokenCrown { get; set; }
    }

    public class Boneyard3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Ruination3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Losthope3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Furiousresolve3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Isleofdread3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Titanscausewayv23
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Secludedgrovev23
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Brokencrown3
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Summary3
    {
        public int points { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string league { get; set; }
        public int tier { get; set; }
        public int mmr { get; set; }
    }

    public class Outcomes_By_Opponent3
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
        public Vanguard12 vanguard { get; set; }
    }

    public class Vanguard12
    {
        public int[] recent_mmr_history { get; set; }
        public Outcomes_By_Duration4 outcomes_by_duration { get; set; }
        public Outcomes_By_Opponent4[] outcomes_by_opponent { get; set; }
        public Outcomes_By_Opponent_Race4 outcomes_by_opponent_race { get; set; }
        public Outcomes_By_Map4 outcomes_by_map { get; set; }
        public Summary4 summary { get; set; }
    }

    public class Outcomes_By_Duration4
    {
        public Infernal4[] infernals { get; set; }
        public Celestial4[] celestials { get; set; }
        public Vanguard13[] vanguard { get; set; }
    }

    public class Infernal4
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestial4
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard13
    {
        public int minute { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Opponent_Race4
    {
        public Infernals4 infernals { get; set; }
        public Celestials4 celestials { get; set; }
        public Vanguard14 vanguard { get; set; }
    }

    public class Infernals4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Celestials4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Vanguard14
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Outcomes_By_Map4
    {
        public Boneyard4 Boneyard { get; set; }
        public Ruination4 Ruination { get; set; }
        public Losthope4 LostHope { get; set; }
        public Furiousresolve4 FuriousResolve { get; set; }
        public Isleofdread4 IsleOfDread { get; set; }
        public Titanscausewayv24 TitansCausewayV2 { get; set; }
        public Secludedgrovev24 SecludedGroveV2 { get; set; }
        public Brokencrown4 BrokenCrown { get; set; }
    }

    public class Boneyard4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Ruination4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Losthope4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Furiousresolve4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Isleofdread4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Titanscausewayv24
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Secludedgrovev24
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Brokencrown4
    {
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }

    public class Summary4
    {
        public int points { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
        public string league { get; set; }
        public int tier { get; set; }
        public int mmr { get; set; }
    }

    public class Outcomes_By_Opponent4
    {
        public string player_name { get; set; }
        public string profile_id { get; set; }
        public string race { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int ties { get; set; }
    }



}
