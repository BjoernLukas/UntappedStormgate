namespace UntappedAPI.DTOs.PlayerLookUpDto
{

    public class PlayerLookUpDto
    {
        public Ranks ranks { get; set; }
        public string playerName { get; set; }
        public string profileId { get; set; }
        public Matchhistoryvisibility matchHistoryVisibility { get; set; }
        public Replayvisibility replayVisibility { get; set; }
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
