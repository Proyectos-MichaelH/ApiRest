using ApiRest.Models;
using ApiRest.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [ApiController]
    [Route("api")]
    public class ApiController : ControllerBase
    {
        private readonly ICatFactService _catFactService;
        private readonly IGiphyService _giphyService;
        private readonly IHistoryService _historyService;

        public ApiController(
            ICatFactService catFactService,
            IGiphyService giphyService,
            IHistoryService historyService)
        {
            _catFactService = catFactService;
            _giphyService = giphyService;
            _historyService = historyService;
        }

        [HttpGet("fact")]
        public async Task<IActionResult> GetFact()
        {
            var catFact = await _catFactService.GetFactAsync();

            if (catFact == null || string.IsNullOrEmpty(catFact.Fact))
            {
                return StatusCode(503, "No se pudo obtener un dato de la API de Cat Facts.");
            }

            return Ok(catFact);
        }

        [HttpGet("gif")]
        public async Task<IActionResult> GetGif([FromQuery] string fact, [FromQuery] bool random = false)
        {
            if (string.IsNullOrWhiteSpace(fact))
            {
                return BadRequest("El parámetro 'fact' es requerido.");
            }

            var query = string.Join(" ", fact.Split(' ').Take(3));
            var giphyData = await _giphyService.SearchGifAsync(query, random);

            if (giphyData?.Images?.Original?.Url == null)
            {
                return NotFound($"No se encontraron GIFs para la búsqueda: '{query}'.");
            }

            if (!random)
            {
                var historyEntry = new SearchHistory
                {
                    Timestamp = DateTime.UtcNow,
                    Query = query,
                    CatFact = fact,
                    GifUrl = giphyData.Images.Original.Url
                };
                await _historyService.SaveSearchAsync(historyEntry);
            }

            return Ok(new { giphyData.Title, GifUrl = giphyData.Images.Original.Url });
        }

        [HttpGet("history")]
        public async Task<IActionResult> GetHistory()
        {
            var history = await _historyService.GetAllHistoryAsync();
            return Ok(history);
        }
    }
}