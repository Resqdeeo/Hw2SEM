using Microsoft.VisualStudio.TestTools.UnitTesting;
using PokemonAPI.Modules.Requests.PokemonsGetByFilter;
using PokemonAPI.Services;
using Assert = NUnit.Framework.Assert;

namespace PokemonAPI.Tests.Requests.PokemonsGetByFilter;

[TestClass]
public class PokemonsGetByFilterTest
{
    private static readonly HttpClient HttpClient = new();
    
    private readonly IPokeApiService _pokeApiService;

    /// <summary>
    /// Конструктор
    /// </summary>
    public PokemonsGetByFilterTest()
        => _pokeApiService = new PokeApiService(HttpClient);

    /// <summary>
    /// Обработчик должен вернуть покемона по поиску
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnPokeBySearch()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 0,
            Limit = 1300,
            Search = "bulbasaur"
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request,
                "https://pokeapi.co/api/v2/pokemon");
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Search, response.Pokemons!.First().Name);
    }

    /// <summary>
    /// Обработчик должен вернуть конкретное кол-во покемонов
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnCountPoke()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 0,
            Limit = 100,
            Search = null
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request: request,
                url: "https://pokeapi.co/api/v2/pokemon");
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Limit, response.Pokemons!.Count);
    }

    /// <summary>
    /// Обработчик должен вернуть покемонов, но пропустить n - кол-во
    /// </summary>
    [TestMethod]
    public async Task HandleShouldReturnCountBeforeOffset()
    {
        var request = new PokemonsGetByFilterRequest
        {
            Offset = 100,
            Limit = 100,
            Search = null
        };

        var response = await _pokeApiService
            .GetPokeDataAsync(
                request: request,
                url: "https://pokeapi.co/api/v2/pokemon");
        
        Assert.IsNotNull(response);
        Assert.AreEqual(request.Offset, response.Pokemons!.Count);
    }
}