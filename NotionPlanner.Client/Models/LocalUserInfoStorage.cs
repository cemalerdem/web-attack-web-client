namespace NotionPlanner.Client.Models
{
    public class LocalUserInfoStorage
    {
        public int  Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string AccessToken { get; set; }
    }   
}