using System.Threading.Tasks;
using NotionPlanner.Shared.Common.Request;
using RestSharp;

namespace NotionPlanner.Client.Models
{
    public class KerasPrediction
    {
        private const string SimpraService = "http://ec2-54-208-76-120.compute-1.amazonaws.com:8080/predict";
        public static async Task<string> GetPredictionResponse(RequestStream requestBody)
        {
            var client = new RestClient(SimpraService);
            var request = new RestRequest(Method.POST) { RequestFormat = DataFormat.Json };
            request.AddJsonBody(requestBody);
            var result = await client.ExecuteAsync<PredictionResponse>(request);
            return result.Data.Result;
        }
    }


    public class PredictionResponse
    {
        public string Result { get; set; }
    }
}