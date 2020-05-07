using System.Collections.Generic;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using NotionPlanner.Shared.Common.Request;

namespace NotionPlanner.Shared.Services
{
    public class AdminService
    {
        private readonly string _baseUrl;

        readonly ServiceClient _client = new ServiceClient();
        public AdminService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<List<RequestStreamResponse>> GetRequestStreamAsync()
        {
            var result = await _client.GetAsync<RequestStreamResponse>($"http://localhost:5000/api/Admin/request-stream");
            return new List<RequestStreamResponse> {result.Result};
        }
    }
}