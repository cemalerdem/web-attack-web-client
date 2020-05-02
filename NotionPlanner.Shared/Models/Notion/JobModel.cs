using NotionPlanner.Shared.Common;
using System;

namespace NotionPlanner.Shared.Models.Notion
{
    public class JobModel
    {
        public int Id { get; set; }
        public JobStatus Status { get; set; }
        public string Detail { get; set; }
        public DateTime UpdatedTime { get; set; }
    }
}