using System.Collections.Generic;

namespace NotionPlanner.Shared.Models.Auth.Response
{
    public class UserRegisterResponse
    {
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}