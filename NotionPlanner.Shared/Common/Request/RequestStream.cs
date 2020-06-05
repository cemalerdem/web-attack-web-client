using System;

namespace NotionPlanner.Shared.Common.Request
{
    public class RequestStream
    {
        public DateTime CreatedAtUTC { get; set; }
        public string Method { get; set; }
        public string Path { get; set; }
        public string StatusCode { get; set; }
        public string Query { get; set; }
        public string RequestPayload { get; set; }
        public string Result { get; set; }
    }
}

public class RequestToPredict
{
    public string method { get; set; }
    public string query { get; set; }
    public string path { get; set; }
    public string statusCode { get; set; }
    public string requestPayload { get; set; }
}

public class Notifications
{
    public DateTime CreatedAtUTC { get; set; }
    public string Method { get; set; }
    public string Path { get; set; }
    public string StatusCode { get; set; }
    public string Query { get; set; }
    public string RequestPayload { get; set; }
    public string Result { get; set; }
}

public class Prediction
{
    public string Result { get; set; }
}