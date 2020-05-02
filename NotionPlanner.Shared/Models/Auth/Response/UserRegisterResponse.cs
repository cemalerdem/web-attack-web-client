namespace NotionPlanner.Shared.Models.Auth
{
    public class UserRegisterResponse
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}