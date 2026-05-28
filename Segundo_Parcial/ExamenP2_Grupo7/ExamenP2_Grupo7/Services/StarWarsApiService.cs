using StarWarsApiWebApp.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace StarWarsApiWebApp.Services
{
    public class StarWarsApiService
    {
        private static readonly HttpClient client = new HttpClient
        {
            BaseAddress = new Uri("https://swapi-api.hbtn.io/api/")
        };

        public async Task<StarWarsResponse> GetListAsync()
        {
            var response = await client.GetAsync("people/");
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<StarWarsResponse>(json);
        }

        public async Task<Personaje> GetByNameAsync(string name)
        {
            var response = await client.GetAsync("people/?search=" + Uri.EscapeDataString(name));
            response.EnsureSuccessStatusCode();

            var json = await response.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<StarWarsResponse>(json);

            if (data.results != null && data.results.Count > 0)
            {
                return data.results[0];
            }

            return null;
        }
    }
}