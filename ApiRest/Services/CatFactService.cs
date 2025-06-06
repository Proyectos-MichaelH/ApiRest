using ApiRest.Models;
using ApiRest.Services;

namespace ApiRest.Services
{
    public class CatFactService : ICatFactService
    {
        private readonly HttpClient _httpClient;

        public CatFactService(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient("CatFactClient");
        }

        public async Task<CatFactDto?> GetFactAsync()
        {
            try
            {
                return await _httpClient.GetFromJsonAsync<CatFactDto>("fact");
            }
            catch (HttpRequestException)
            {
                return null;
            }
        }
    }
}