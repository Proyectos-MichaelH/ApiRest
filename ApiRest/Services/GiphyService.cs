using ApiRest.Models;
using System;

namespace ApiRest.Services
{
    public class GiphyService : IGiphyService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;
        private static readonly Random _random = new Random();

        public GiphyService(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient("GiphyClient");
            _apiKey = configuration["Giphy:ApiKey"]!;
        }

        //public async Task<GiphyData?> SearchGifAsync(string query)
        //{
        //    var requestUri = $"search?api_key={_apiKey}&q={Uri.EscapeDataString(query)}&limit=1";

        //    //var randomOffset = _random.Next(0, 100);
        //    //var requestUri = $"search?api_key={_apiKey}&q={Uri.EscapeDataString(query)}&limit=1&offset={randomOffset}";
        //    try
        //    {
        //        var giphyResult = await _httpClient.GetFromJsonAsync<GiphySearchResult>(requestUri);
        //        return giphyResult?.Data?.FirstOrDefault();
        //    }
        //    catch (HttpRequestException)
        //    {
        //        return null;
        //    }
        //}

        public async Task<GiphyData?> SearchGifAsync(string query, bool esAleatorio = false)
        {
            string requestUri;
            
            if (esAleatorio)
            {
                var randomOffset = _random.Next(0, 100);
                requestUri = $"search?api_key={_apiKey}&q={Uri.EscapeDataString(query)}&limit=1&offset={randomOffset}";
            }
            else
            {
                requestUri = $"search?api_key={_apiKey}&q={Uri.EscapeDataString(query)}&limit=1";
            }

            try
            {
                var giphyResult = await _httpClient.GetFromJsonAsync<GiphySearchResult>(requestUri);
                return giphyResult?.Data?.FirstOrDefault();
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}