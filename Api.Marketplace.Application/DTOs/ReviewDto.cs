using Api.Marketplace.Domain.Entities;
using System.Text.Json.Serialization;

namespace Api.Marketplace.Application.DTOs
{
    public class ReviewDto
    {
        [JsonPropertyName(nameof(Rating))]
        public int Rating { get; set; }

        [JsonPropertyName(nameof(Comment))]
        public string Comment { get; set; }
    }
}
