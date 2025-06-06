using ApiRest.Models;

namespace ApiRest.Services
{
    public interface IGiphyService
    {
        //Task<GiphyData?> SearchGifAsync(string query);
        Task<GiphyData?> SearchGifAsync(string query, bool esAleatorio = false);
    }
}