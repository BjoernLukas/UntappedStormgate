﻿namespace UntappedAPI.DTOs
{
    public class MetaPeriodDto
    {

        public int Id { get; set; }
        public string Description { get; set; }
        public string MatchMode { get; set; }
        public string StartClientVersion { get; set; }
        public DateTime StartTimestamp { get; set; }
        public DateTime? EndTimestamp { get; set; }
    }




}