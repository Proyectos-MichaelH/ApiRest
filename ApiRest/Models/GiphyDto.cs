using System.Text.Json.Serialization;

namespace ApiRest.Models
{
    public class GiphySearchResult
    {
        [JsonPropertyName("data")]
        public GiphyData[]? Data { get; set; }
    }

    public class GiphyData
    {
        [JsonPropertyName("title")]
        public string? Title { get; set; }

        [JsonPropertyName("images")]
        public GiphyImages? Images { get; set; }
    }

    public class GiphyImages
    {
        [JsonPropertyName("original")]
        public GiphyImageDetail? Original { get; set; }
    }

    public class GiphyImageDetail
    {
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}