namespace ApiRest.Models
{
    public class SearchHistory
    {
        public int Id { get; set; }
        public DateTime Timestamp { get; set; }
        public string? CatFact { get; set; }
        public string? Query { get; set; }
        public string? GifUrl { get; set; }
    }
}



