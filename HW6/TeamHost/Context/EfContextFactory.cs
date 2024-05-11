using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace TeamHost.Context;

/// <summary>
/// Фабрика для запуска EfContext который находится в отдельном слое
/// </summary>
public class EfContextFactory : IDesignTimeDbContextFactory<EfContext>
{
    /// <inheritdoc />
    public EfContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false)
            .AddEnvironmentVariables()
            .Build();
        
        var optionBuilder = new DbContextOptionsBuilder<EfContext>();
        optionBuilder.UseNpgsql(config.GetConnectionString("DefaultConnection"));

        return new EfContext(optionBuilder.Options);
    }
}