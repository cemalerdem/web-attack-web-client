using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;
using NotionPlanner.Client.Models;

namespace NotionPlanner.Client
{
    public class LocalAuthenticationStateProvider : AuthenticationStateProvider
    {

        private readonly ILocalStorageService _localStorageService;

        public LocalAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }

        ///return the user or authentication state user claimes info
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            if(await _localStorageService.ContainKeyAsync("User"))
            {
                var userInfo = await _localStorageService.GetItemAsync<LocalUserInfoStorage>("User");

                var claims = new []
                {
                    new Claim("Id", userInfo.Email),
                    new Claim("AccessToken", userInfo.AccessToken),
                    new Claim(ClaimTypes.NameIdentifier, userInfo.Email)
                };

                var identity = new ClaimsIdentity(claims, "Bearer");
                var user = new ClaimsPrincipal(identity);

                return new AuthenticationState(user);                
            }

            return new AuthenticationState(new ClaimsPrincipal());
        }
    }
}