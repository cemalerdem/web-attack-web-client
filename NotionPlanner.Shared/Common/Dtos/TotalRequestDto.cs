using System;

namespace NotionPlanner.Shared.Common.Dtos
{
    public class TotalRequestDto
    {
        public string Method { get; set; }
        public int Count { get; set; }
    }
    public class WeeklyRequest
    {
        public DateTime WeekDay { get; set; }
        public int Count { get; set; }
    }
}