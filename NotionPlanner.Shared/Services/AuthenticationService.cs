using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using NotionPlanner.Shared.Models.Auth;
using NotionPlanner.Shared.Models.Auth.Response;

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
            var result = await client.PostAsync<UserRegisterResponse>($"{_baseUrl}api/Auth/register", request);
            return result.Result;
        }

        public async Task<LoginResponse> LoginUserAsync(LoginRequest request)
        {

            var result = await client.PostAsync<LoginResponse>($"{_baseUrl}api/Auth/login", request);
            return result.Result;
        }
    }
}