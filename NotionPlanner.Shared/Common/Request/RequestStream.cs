using System;

namespace NotionPlanner.Shared.Common.Request
{
    public class RequestStream
    {
        public double timestamp { get; set; }
        public string method { get; set; }
        public string path { get; set; }
        public string statusCode { get; set; }
        public string query { get; set; }
        public string requestPayload { get; set; }
        public string result { get; set; }
    }
}