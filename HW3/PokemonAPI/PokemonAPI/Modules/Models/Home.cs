using Newtonsoft.Json;

namespace PokemonAPI.Modules.Models;

/// <summary>
/// Ссылки для фоток
/// </summary>
public class Home
{
    /// <summary>
    /// Картинка покемона для фронта
    /// </summary>
    [JsonProperty("front_default")]
    public string? FrontDefault { get; set; }
}