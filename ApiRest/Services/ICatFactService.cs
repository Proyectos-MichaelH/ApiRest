using ApiRest.Models;

namespace ApiRest.Services
{
    public interface ICatFactService
    {
        Task<CatFactDto?> GetFactAsync();
    }
}