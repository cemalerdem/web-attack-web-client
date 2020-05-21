using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.DependencyInjection;
using NotionPlanner.Shared.Services;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace NotionPlanner.Client
{
    public class Program
    {
        private const string URL = "http://localhost:5000";
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.Services.AddScoped<AuthenticationService>(s=> new AuthenticationService(URL));
            builder.Services.AddScoped<AdminService>(s => new AdminService(URL));
            builder.Services.AddBlazoredLocalStorage();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddOptions();
            builder.Services.AddScoped<AuthenticationStateProvider, LocalAuthenticationStateProvider>();
            builder.RootComponents.Add<App>("app");
            
            builder.Services.AddSingleton(new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            await builder.Build().RunAsync();
        }
    }
}
