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

        public async Task<List<RequestStream>> GetRequestStreamAsync()
        {
            var result = await _client.GetAsync<RequestStream>($"http://localhost:5000/api/Admin/request-stream");
            return new List<RequestStream> {result.Result};
        }
    }
}