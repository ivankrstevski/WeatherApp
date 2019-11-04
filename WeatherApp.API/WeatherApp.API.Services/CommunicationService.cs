using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.API.Services.Interfaces;

namespace WeatherApp.API.Services
{
    public class CommunicationService
    {
        public HttpClient _httpClient { get; set; }

        public CommunicationService(string baseAdress)
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri(baseAdress)
            };
        }

        public async Task<T> Get<T>(string method)
        {
            var response = _httpClient
                .GetAsync($"{_httpClient.BaseAddress}{method}");

            string json = await response
                .Result.Content.ReadAsStringAsync();

            if (response.Result.IsSuccessStatusCode)
            {
                var result = JsonConvert.DeserializeObject<T>(json);

                return result;
            }
            else
            {
                throw new Exception(json);
            }
        }
    }
}
