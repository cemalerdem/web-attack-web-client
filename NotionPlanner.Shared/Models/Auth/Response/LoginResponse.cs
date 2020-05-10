using System;
using System.Collections.Generic;

namespace NotionPlanner.Shared.Models.Auth.Response
{
    public class LoginResponse
    {
        public bool Successful { get; set; }
        public string Error { get; set; }
        public string Token { get; set; }
        public Dictionary<string, string> UserInfo { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
  
}