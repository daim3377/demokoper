using System.Text.Json.Serialization;

namespace FastDemo.Models;

public class Response
{
    [JsonPropertyName("value")]
    public string? Value { get; set; }
}
