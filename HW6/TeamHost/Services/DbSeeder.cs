using Microsoft.EntityFrameworkCore;
using TeamHost.Entities;
using TeamHost.Interfaces;
using TeamHost.Models;

namespace TeamHost.Services;

public class DbSeeder : IDbSeeder
{
    private readonly IDbContext _dbContext;

    public DbSeeder(IDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <inheritdoc />
    public async Task SeedAsync(CancellationToken cancellationToken)
    {
        await SeedBaseCountriesAsync(dbContext: _dbContext, cancellationToken: cancellationToken);
    }
    
    private static async Task SeedBaseCountriesAsync(IDbContext dbContext, CancellationToken cancellationToken)
    {
        var allCountries = await dbContext.Countries
            .GroupBy(x => x.Name)
            .ToDictionaryAsync(
                x => x.Key,
                x => x.ToList(),
                cancellationToken);
        
        foreach (var (key, value) in allCountries)
        {
            if (BaseCountries.AllBaseCountries.ContainsKey(key))
                continue;

            dbContext.Countries.Remove(value.First());
        }

        foreach (var (countryName, alphaThree) in BaseCountries.AllBaseCountries)
        {
            if (allCountries.ContainsKey(countryName))
                continue;
            
            await dbContext.Countries.AddAsync(new Country
            {
                Id = Guid.NewGuid(),
                Name = countryName,
                Code = 0,
                AplhaThree = alphaThree,
            }, cancellationToken);
        }

        await dbContext.SaveChangesAsync(cancellationToken);
    }
}