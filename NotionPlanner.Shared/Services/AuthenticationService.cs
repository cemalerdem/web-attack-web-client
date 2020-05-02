using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using NotionPlanner.Shared.Models.Auth;

namespace NotionPlanner.Shared.Services
{
    public class AuthenticationService
    {
        private readonly string _baseUrl;

        ServiceClient client = new ServiceClient();

        public AuthenticationService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<UserRegisterResponse> RegisterUserAsync(RegisterRequest request)
        {
            var result = await client.PostAsync<UserRegisterResponse>($"http://localhost:5000/api/user/register", request);
            return result.Result;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
        {

            var result = await client.PostAsync<LoginResponse>($"http://localhost:5000/api/user/login", request);
            return result.Result;
        }
    }
}