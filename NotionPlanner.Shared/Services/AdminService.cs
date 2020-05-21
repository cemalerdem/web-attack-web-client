using System.Collections.Generic;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using NotionPlanner.Shared.Common.Request;
using RestSharp;

namespace NotionPlanner.Shared.Services
{
    public class AdminService
    {
        private readonly string _baseUrl;
        private const string kerasUrl = "http://localhost:5001/predict";
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

        public async Task<PredictionResponse> PredictionRequestModel(RequestStream request)
        {
            var result = await _client.PostAsync<PredictionResponse>($"http://localhost:5001/predict",request);
            return result.Result;
        }

        public static PredictionResponse GetPredictionResponse(RequestStream requestBody)
        {
            var client = new RestClient(kerasUrl);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(requestBody);
            return client.Execute<PredictionResponse>(request).Data;
        }
    }
}