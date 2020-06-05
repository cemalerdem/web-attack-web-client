using System.Collections.Generic;
using System.Threading.Tasks;
using AKSoftware.WebApi.Client;
using NotionPlanner.Shared.Common.Dtos;
using NotionPlanner.Shared.Common.Request;
using RestSharp;

namespace NotionPlanner.Shared.Services
{
    public class AdminService
    {
        private readonly string _baseUrl;
        private const string kerasUrl = "http://ec2-54-208-76-120.compute-1.amazonaws.com:8080/predict";
        readonly ServiceClient _client = new ServiceClient();
        public AdminService(string baseUrl)
        {
            _baseUrl = baseUrl;
        }

        public async Task<List<TotalRequestDto>> GetRequestCard()
        {
            var result = await _client.GetAsync<List<TotalRequestDto>>($"https://webattackapi.azurewebsites.net/api/Dashboard");
            return result.Result;
        }

        public async Task<List<WeeklyRequest>> GetWeeklyRequests()
        {
            var result = await _client.GetAsync<List<WeeklyRequest>>($"https://webattackapi.azurewebsites.net/api/Dashboard/weekly-request");
            return result.Result;
        }

        public async Task<List<RequestStream>> GetRequestStreamAsync()
        {
            var result = await _client.GetAsync<RequestStream>($"https://webattackapi.azurewebsites.net/api/Admin/request-stream");
            return new List<RequestStream> { result.Result };
        }

        public PredictionResponse PredictionRequestModel(RequestToPredict request)
        {
            PredictionResponse result =  _client.PostAsync<PredictionResponse>($"http://ec2-54-208-76-120.compute-1.amazonaws.com:8080/predict", request).Result.Result;
            return result;
        }

        public PredictionResponse GetPredictionResponse(RequestToPredict requestBody)
        {
            var client = new RestClient(kerasUrl);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(requestBody);
            return client.Execute<PredictionResponse>(request).Data;
        }
    }
}
