using DigiApiWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiApiWebApp.Services
{
    public class DigiApiService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://digi-api.com/api/v1/")
        };

        public async Task<DigimonResponse> GetListAsync()
        {
            var response = await client.GetAsync("digimon");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<DigimonResponse>(json);
        }

        public async Task<Digimon> GetByNameAsync(string name)
        {
            var response = await client.GetAsync("digimon/" + name);
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<Digimon>(json);
        }
    }
}