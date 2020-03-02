using BankingMicroRabbit.Mvc.Models.DTO;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankingMicroRabbit.Mvc.Services
{
    public class TransferService : ITransferService
    {
        private readonly HttpClient _apiClient;
        public TransferService(HttpClient apiClient)
        {
            _apiClient = apiClient;
        }

        public async Task Transfer(TransferDTO transferDTO)
        {
            var uri = @"https://localhost:5011/api/banking";
            var content = new StringContent(JsonConvert.SerializeObject(transferDTO), Encoding.UTF8, "application/json");
            var response = await _apiClient.PostAsync(uri, content);

            response.EnsureSuccessStatusCode();
        }
    }
}
